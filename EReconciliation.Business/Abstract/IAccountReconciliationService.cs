using EReconciliation.Core.Utilities.Results.Abstract;
using EReconciliation.Entities.Concrete;

namespace EReconciliation.Business.Abstract
{
    public interface IAccountReconciliationService
    {
        IResult Add(AccountReconciliation accountReconciliation);
        IResult AddToExcel(string filePath, int companyId);
        IResult Update(AccountReconciliation accountReconciliation);
        IResult Delete(AccountReconciliation accountReconciliation);
        IDataResult<AccountReconciliation> GetById(int id);
        IDataResult<List<AccountReconciliation>> GetList(int companyId);
    }
}
