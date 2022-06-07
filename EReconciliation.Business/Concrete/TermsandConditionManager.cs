using EReconciliation.Business.Abstract;
using EReconciliation.Business.BusinessAcpects;
using EReconciliation.Business.Constants;
using EReconciliation.Core.Utilities.Results.Abstract;
using EReconciliation.Core.Utilities.Results.Concrete;
using EReconciliation.DataAccess.Abstract;
using EReconciliation.Entities.Concrete;

namespace EReconciliation.Business.Concrete
{
    public class TermsandConditionManager : ITermsandConditionService
    {
        private readonly ITermsandConditionDal _termsandConditionDal;

        public TermsandConditionManager(ITermsandConditionDal termsandConditionDal)
        {
            _termsandConditionDal = termsandConditionDal;
        }

        //[SecuredOperation("Admin")]
        public IDataResult<TermsandCondition> Get()
        {
            return new SuccessDataResult<TermsandCondition>(_termsandConditionDal.GetList().FirstOrDefault());
        }

        [SecuredOperation("Admin")]
        public IResult Update(TermsandCondition termsandCondition)
        {
            var result = _termsandConditionDal.GetList().FirstOrDefault();
            if (result != null)
            {
                result.Description = termsandCondition.Description;
                _termsandConditionDal.Update(result);
            }
            else
            {
                _termsandConditionDal.Add(termsandCondition);
            }
            return new SuccessResult(Messages.UpdateTermsAndConditions);
        }
    }
}
