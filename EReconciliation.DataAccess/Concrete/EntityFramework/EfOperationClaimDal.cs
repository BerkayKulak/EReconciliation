using EReconciliation.Core.DataAccess.EntityFrameowork;
using EReconciliation.Core.Entities.Concrete;
using EReconciliation.DataAccess.Abstract;
using EReconciliation.DataAccess.Concrete.EntityFramework.Context;

namespace EReconciliation.DataAccess.Concrete.EntityFramework
{
    public class EfOperationClaimDal : EfEntityRepositoryBase<OperationClaim, ContextDb>, IOperationClaimDal
    {
    }
}
