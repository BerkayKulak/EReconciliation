using EReconciliation.Core.DataAccess.EntityFrameowork;
using EReconciliation.DataAccess.Abstract;
using EReconciliation.DataAccess.Concrete.EntityFramework.Context;
using EReconciliation.Entities.Concrete;

namespace EReconciliation.DataAccess.Concrete.EntityFramework
{
    public class EfBaBsReconciliationDal : EfEntityRepositoryBase<BaBsReconciliation, ContextDb>, IBaBsReconciliationDal
    {
    }
}
