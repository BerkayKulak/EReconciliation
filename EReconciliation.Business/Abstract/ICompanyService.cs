using EReconciliation.Entities.Concrete;

namespace EReconciliation.Business.Abstract
{
    public interface ICompanyService
    {
        List<Company> GetList();
    }
}
