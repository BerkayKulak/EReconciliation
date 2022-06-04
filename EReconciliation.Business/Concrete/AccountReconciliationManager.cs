using EReconciliation.Business.Abstract;
using EReconciliation.DataAccess.Abstract;

namespace EReconciliation.Business.Concrete
{
    public class AccountReconciliationManager : IAccountReconciliationService
    {
        private readonly IAccountReconciliationDal _accountReconciliationDal;

        public AccountReconciliationManager(IAccountReconciliationDal accountReconciliationDal)
        {
            _accountReconciliationDal = accountReconciliationDal;
        }
    }
}
