using EReconciliation.Core.Utilities.Results.Abstract;
using EReconciliation.Entities.Concrete;

namespace EReconciliation.Business.Abstract
{
    public interface ITermsandConditionService
    {
        IResult Update(TermsandCondition termsandCondition);
        IDataResult<TermsandCondition> Get();
    }
}
