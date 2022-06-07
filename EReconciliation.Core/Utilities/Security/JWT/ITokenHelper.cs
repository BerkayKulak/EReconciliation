using EReconciliation.Core.Entities.Concrete;

namespace EReconciliation.Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims, int companyId, string companyName);
    }
}
