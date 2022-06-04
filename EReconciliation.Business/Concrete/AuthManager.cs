using EReconciliation.Business.Abstract;
using EReconciliation.Business.Constants;
using EReconciliation.Core.Entities.Concrete;
using EReconciliation.Core.Utilities.Hashing;
using EReconciliation.Core.Utilities.Results.Abstract;
using EReconciliation.Core.Utilities.Results.Concrete;
using EReconciliation.Core.Utilities.Security.JWT;
using EReconciliation.Entities.Dtos;

namespace EReconciliation.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;

        public AuthManager(IUserService userService)
        {
            _userService = userService;
        }

        public IDataResult<User> Register(UserForRegister userForRegister, string password)
        {
            throw new NotImplementedException();
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

        public IResult UserExists(string email)
        {
            throw new NotImplementedException();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            throw new NotImplementedException();
        }
    }
}
