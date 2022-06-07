using EReconciliation.Core.DataAccess;
using EReconciliation.Entities.Concrete;

namespace EReconciliation.DataAccess.Abstract
{
    public interface IForgotPasswordDal : IEntityRepository<ForgotPassword>
    {
    }
}
