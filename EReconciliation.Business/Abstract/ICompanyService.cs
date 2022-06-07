using EReconciliation.Core.Entities.Concrete;
using EReconciliation.Core.Utilities.Results.Abstract;
using EReconciliation.Entities.Concrete;
using EReconciliation.Entities.Dtos;

namespace EReconciliation.Business.Abstract
{
    public interface ICompanyService
    {
        IResult Add(Company company);
        IResult Update(Company company);
        IDataResult<Company> GetById(int id);
        IResult AddCompanyAndUserCompany(CompanyDto companyDto);
        IDataResult<List<Company>> GetList();
        IDataResult<UserCompany> GetCompany(int userId);
        IResult CompanyExists(Company company);
        IResult UserCompanyAdd(int userId, int companyId);
    }
}

