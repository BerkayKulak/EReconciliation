using EReconciliation.Business.Abstract;
using EReconciliation.DataAccess.Abstract;

namespace EReconciliation.Business.Concrete
{
    public class CurrencyAccountManager : ICurrencyService
    {
        private readonly ICurrencyDal _currencyDal;

        public CurrencyAccountManager(ICurrencyDal currencyDal)
        {
            _currencyDal = currencyDal;
        }
    }
}
