using EReconciliation.Core.DataAccess;
using EReconciliation.Core.Entities.Concrete;

namespace EReconciliation.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
    }
}
