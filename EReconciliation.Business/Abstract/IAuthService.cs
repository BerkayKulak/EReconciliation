using EReconciliation.Core.Entities.Concrete;
using EReconciliation.Core.Utilities.Results.Abstract;
using EReconciliation.Core.Utilities.Security.JWT;
using EReconciliation.Entities.Concrete;
using EReconciliation.Entities.Dtos;

namespace EReconciliation.Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<UserCompanyDto> Register(UserForRegister userForRegister, string password, Company company);
        IDataResult<List<UserReletionshipDto>> RegisterSecondAccount(UserForRegister userForRegister, string password, int companyId, int adminUserId);
        IDataResult<User> Login(UserForLogin userForLogin);
        IDataResult<User> GetByMailConfirmValue(string value);
        IDataResult<User> GetById(int id);
        IDataResult<User> GetByEmail(string email);
        IResult UserExists(string email);
        IResult Update(User user);
        IResult ChangePassword(User user);
        IResult CompanyExists(Company company);
        IResult SendConfirmEmailAgain(User user);
        IDataResult<AccessToken> CreateAccessToken(User user, int companyId);
        IDataResult<UserCompany> GetCompany(int userId);
        IResult SendForgotPasswordEmail(User user, string value);
    }
}
