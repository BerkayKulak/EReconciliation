using EReconciliation.Core.DataAccess;
using EReconciliation.Core.Entities.Concrete;
using EReconciliation.Entities.Dtos;

namespace EReconciliation.DataAccess.Abstract
{
    public interface IUserOperationClaimDal : IEntityRepository<UserOperationClaim>
    {
        List<UserOperationClaimDto> GetListDto(int userId, int companyId);
    }
}
