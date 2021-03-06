using EReconciliation.Core.Utilities.Results.Abstract;
using EReconciliation.Entities.Concrete;

namespace EReconciliation.Business.Abstract
{
    public interface IAccountReconciliationDetailService
    {
        IResult Add(AccountReconciliationDetail accountReconciliationDetail);
        IResult AddToExcel(string filePath, int companyId);
        IResult Update(AccountReconciliationDetail accountReconciliationDetail);
        IResult Delete(AccountReconciliationDetail accountReconciliationDetail);
        IDataResult<AccountReconciliationDetail> GetById(int id);
        IDataResult<List<AccountReconciliationDetail>> GetList(int accountReconciliationId);
    }
}
