using EReconciliation.Core.Entities.Concrete;
using EReconciliation.Core.Utilities.Results.Abstract;
using EReconciliation.Core.Utilities.Security.JWT;
using EReconciliation.Entities.Dtos;

namespace EReconciliation.Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegister userForRegister, string password);
        IDataResult<User> Login(UserForLogin userForLogin);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user, int companyId);
    }
}
