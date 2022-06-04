using EReconciliation.Business.Abstract;
using EReconciliation.DataAccess.Abstract;

namespace EReconciliation.Business.Concrete
{
    public class CurrencyAccountManager : ICurrencyAccountService
    {
        private readonly ICurrencyAccountDal _currencyAccountDal;

        public CurrencyAccountManager(ICurrencyAccountDal currencyAccountDal)
        {
            _currencyAccountDal = currencyAccountDal;
        }
    }
}
