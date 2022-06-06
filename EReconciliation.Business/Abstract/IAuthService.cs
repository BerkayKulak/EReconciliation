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
        IDataResult<User> RegisterSecondAccount(UserForRegister userForRegister, string password, int companyId);
        IDataResult<User> Login(UserForLogin userForLogin);
        IDataResult<User> GetByMailConfirmValue(string value);
        IDataResult<User> GetById(int id);
        IResult UserExists(string email);
        IResult Update(User user);
        IResult CompanyExists(Company company);
        IResult SendConfirmEmail(User user);
        IDataResult<AccessToken> CreateAccessToken(User user, int companyId);
        IDataResult<UserCompany> GetCompany(int userId);
    }
}
