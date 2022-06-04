using EReconciliation.Business.Abstract;
using EReconciliation.Business.Constants;
using EReconciliation.Core.Utilities.Results.Abstract;
using EReconciliation.Core.Utilities.Results.Concrete;
using EReconciliation.DataAccess.Abstract;
using EReconciliation.Entities.Concrete;

namespace EReconciliation.Business.Concrete
{
    public class CompanyManager : ICompanyService
    {
        private readonly ICompanyDal _companyDal;

        public CompanyManager(ICompanyDal companyDal)
        {
            _companyDal = companyDal;
        }


        public IResult Add(Company company)
        {
            _companyDal.Add(company);
            return new SuccessResult(Messages.AddedCompany);
        }

        public IDataResult<List<Company>> GetList()
        {
            return new SuccessDataResult<List<Company>>(_companyDal.GetList());
        }
    }
}
