﻿using EReconciliation.Business.Abstract;
using EReconciliation.Business.Constants;
using EReconciliation.Core.Utilities.Results.Abstract;
using EReconciliation.Core.Utilities.Results.Concrete;
using EReconciliation.DataAccess.Abstract;
using EReconciliation.Entities.Concrete;

namespace EReconciliation.Business.Concrete
{
    public class CurrencyAccountManager : ICurrencyAccountService
    {
        private readonly ICurrencyAccountDal _currencyAccountDal;

        public CurrencyAccountManager(ICurrencyAccountDal currencyAccountDal)
        {
            _currencyAccountDal = currencyAccountDal;
        }

        public IResult Add(CurrencyAccount currencyAccount)
        {
            _currencyAccountDal.Add(currencyAccount);
            return new SuccessResult(Messages.AddedCurrencyAccount);
        }

        public IResult Update(CurrencyAccount currencyAccount)
        {
            _currencyAccountDal.Update(currencyAccount);
            return new SuccessResult(Messages.UpdatedCurrencyAccount);
        }

        public IResult Delete(CurrencyAccount currencyAccount)
        {
            _currencyAccountDal.Delete(currencyAccount);
            return new SuccessResult(Messages.DeletedCurrencyAccount);
        }

        public IDataResult<CurrencyAccount> Get(int id)
        {
            return new SuccessDataResult<CurrencyAccount>(_currencyAccountDal.Get(p => p.Id == id));
        }

        public IDataResult<List<CurrencyAccount>> GetList(int companyId)
        {
            return new SuccessDataResult<List<CurrencyAccount>>(_currencyAccountDal.GetList(p => p.CompanyId == companyId));
        }
    }
}
