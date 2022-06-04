using EReconciliation.Business.Abstract;
using EReconciliation.DataAccess.Abstract;

namespace EReconciliation.Business.Concrete
{
    public class CurrencyManager : ICurrencyService
    {
        private readonly ICurrencyDal _currencyDal;

        public CurrencyManager(ICurrencyDal currencyDal)
        {
            _currencyDal = currencyDal;
        }
    }
}
