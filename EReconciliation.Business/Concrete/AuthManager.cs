using EReconciliation.Business.Abstract;
using EReconciliation.Business.Constants;
using EReconciliation.Business.ValidationRules.FluentValidation;
using EReconciliation.Core.CrossCuttingConcerns.Validation;
using EReconciliation.Core.Entities.Concrete;
using EReconciliation.Core.Utilities.Hashing;
using EReconciliation.Core.Utilities.Results.Abstract;
using EReconciliation.Core.Utilities.Results.Concrete;
using EReconciliation.Core.Utilities.Security.JWT;
using EReconciliation.Entities.Concrete;
using EReconciliation.Entities.Dtos;

namespace EReconciliation.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenHelper _tokenHelper;
        private readonly ICompanyService _companyService;
        private readonly IMailService _mailService;
        private readonly IMailParameterService _mailParameterService;
        private readonly IMailTemplateService _mailTemplateService;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper, ICompanyService companyService, IMailService mailService, IMailParameterService mailParameterService, IMailTemplateService mailTemplateService)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _companyService = companyService;
            _mailService = mailService;
            _mailParameterService = mailParameterService;
            _mailTemplateService = mailTemplateService;
        }


        public IDataResult<UserCompanyDto> Register(UserForRegister userForRegister, string password, Company company)
        {


            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User()
            {
                Email = userForRegister.Email,
                AddedAt = DateTime.Now,
                IsActive = true,
                MailConfirm = false,
                MailConfirmDate = DateTime.Now,
                MailConfirmValue = Guid.NewGuid().ToString(),
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Name = userForRegister.Name
            };


            ValidationTool.Validate(new UserValidator(), user);
            ValidationTool.Validate(new CompanyValidator(), company);

            _userService.Add(user);
            _companyService.Add(company);
            _companyService.UserCompanyAdd(user.Id, company.Id);

            UserCompanyDto userCompanyDto = new UserCompanyDto()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                AddedAt = user.AddedAt,
                CompanyId = company.Id,
                IsActive = true,
                MailConfirm = user.MailConfirm,
                MailConfirmDate = user.MailConfirmDate,
                MailConfirmValue = user.MailConfirmValue,
                PasswordHash = user.PasswordHash,
                PasswordSalt = user.PasswordSalt
            };


            SendConfirmEmail(user);


            return new SuccessDataResult<UserCompanyDto>(userCompanyDto, Messages.UserRegistered);
        }


        void SendConfirmEmail(User user)
        {
            string subject = "Kullanıcı Kayıt Onay Maili";
            string titleMessage = "Onay Maili";
            string link = "https://localhost:7240/api/Auth/confirmuser?value=" + user.MailConfirmValue;
            string linkDescription = "Kaydı onaylamak için tıklayın";
            string body = "Kullanıcınız sisteme kayıt oldu. Kaydınızı tamamlamak için aşağıdaki linke tıklamanız gerekmektedir";

            var mailTemplate = _mailTemplateService.GetByTemplateName("Kayıt", 4);
            string tempateBody = mailTemplate.Data.Value;
            tempateBody = tempateBody.Replace("{{title}}", subject);
            tempateBody = tempateBody.Replace("{{message}}", body);
            tempateBody = tempateBody.Replace("{{link}}", link);
            tempateBody = tempateBody.Replace("{{linkDescription}}", linkDescription);

            var mailParameter = _mailParameterService.Get(4);
            SendMailDto sendMailDto = new SendMailDto()
            {
                MailParameter = mailParameter.Data,
                Email = user.Email,
                Subject = "Kullanıcı Kayıt Onay Maili",
                Body = tempateBody

            };

            _mailService.SendMail(sendMailDto);

            user.MailConfirmDate = DateTime.Now;
            _userService.Update(user);
        }


        public IDataResult<User> RegisterSecondAccount(UserForRegister userForRegister, string password, int companyId)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User()
            {
                Email = userForRegister.Email,
                AddedAt = DateTime.Now,
                IsActive = true,
                MailConfirm = false,
                MailConfirmDate = DateTime.Now,
                MailConfirmValue = Guid.NewGuid().ToString(),
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Name = userForRegister.Name
            };
            _userService.Add(user);

            _companyService.UserCompanyAdd(user.Id, companyId);

            SendConfirmEmail(user);

            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IDataResult<User> Login(UserForLogin userForLogin)
        {
            var userToCheck = _userService.GetByMail(userForLogin.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLogin.Password, userToCheck.PasswordHash,
                    userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
        }

        public IDataResult<User> GetByMailConfirmValue(string value)
        {
            return new SuccessDataResult<User>(_userService.GetByMailConfirmValue(value));
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userService.GetById(id));
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }

        public IResult Update(User user)
        {
            _userService.Update(user);
            return new SuccessResult(Messages.UserMailConfirmSuccessful);
        }

        public IResult CompanyExists(Company company)
        {
            var result = _companyService.CompanyExists(company);

            if (result.Success == false)
            {
                return new ErrorResult(Messages.CompanyExists);
            }

            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user, int companyId)
        {
            var claims = _userService.GetClaims(user, companyId);
            var accessToken = _tokenHelper.CreateToken(user, claims, companyId);
            return new SuccessDataResult<AccessToken>(accessToken);
        }

        public IDataResult<UserCompany> GetCompany(int userId)
        {
            return new SuccessDataResult<UserCompany>(_companyService.GetCompany(userId).Data);
        }

        IResult IAuthService.SendConfirmEmail(User user)
        {
            if (user.MailConfirm == true)
            {
                return new ErrorResult(Messages.MailAlreadyConfirm);
            }

            DateTime confirmMailDate = user.MailConfirmDate;

            DateTime now = DateTime.Now;

            if (confirmMailDate.ToShortDateString() == now.ToShortDateString())
            {
                if (confirmMailDate.Hour == now.Hour && confirmMailDate.AddMinutes(5).Minute <= now.Minute)
                {
                    SendConfirmEmail(user);
                    return new SuccessResult(Messages.MailConfirmSendSuccessful);

                }
                else
                {
                    return new ErrorResult(Messages.MailConfirmTimeHasNotExpired);
                }
            }
            SendConfirmEmail(user);
            return new SuccessResult(Messages.MailConfirmSendSuccessful);


        }
    }
}
