using EReconciliation.Core.Utilities.Results.Abstract;
using EReconciliation.Entities.Concrete;

namespace EReconciliation.Business.Abstract
{
    public interface ICompanyService
    {
        IResult Add(Company company);
        IDataResult<List<Company>> GetList();
        IResult CompanyExists(Company company);
    }
}

