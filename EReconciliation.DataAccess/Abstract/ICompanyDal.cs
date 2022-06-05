using EReconciliation.Core.DataAccess;
using EReconciliation.Entities.Concrete;

namespace EReconciliation.DataAccess.Abstract
{
    public interface ICompanyDal : IEntityRepository<Company>
    {
        void UserCompanyAdd(int userId, int companyId);
    }
}
