using EReconciliation.Core.Entities.Concrete;
using EReconciliation.Core.Utilities.Results.Abstract;
using EReconciliation.Entities.Concrete;

namespace EReconciliation.Business.Abstract
{
    public interface ICompanyService
    {
        IResult Add(Company company);
        IDataResult<List<Company>> GetList();
        IDataResult<UserCompany> GetCompany(int userId);
        IResult CompanyExists(Company company);
        IResult UserCompanyAdd(int userId, int companyId);
    }
}

