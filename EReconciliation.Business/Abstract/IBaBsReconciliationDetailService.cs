using EReconciliation.Core.Utilities.Results.Abstract;
using EReconciliation.Entities.Concrete;

namespace EReconciliation.Business.Abstract
{
    public interface IBaBsReconciliationDetailService
    {
        IResult Add(BaBsReconciliationDetail babsReconciliationDetail);
        IResult AddToExcel(string filePath, int companyId);
        IResult Update(BaBsReconciliationDetail babsReconciliationDetail);
        IResult Delete(BaBsReconciliationDetail babsReconciliationDetail);
        IDataResult<BaBsReconciliationDetail> GetById(int id);
        IDataResult<List<BaBsReconciliationDetail>> GetList(int babsReconciliationId);
    }
}
