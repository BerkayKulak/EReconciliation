using EReconciliation.Business.Abstract;
using EReconciliation.Business.Constants;
using EReconciliation.Core.Utilities.Results.Abstract;
using EReconciliation.Core.Utilities.Results.Concrete;
using EReconciliation.DataAccess.Abstract;
using EReconciliation.Entities.Concrete;
using EReconciliation.Entities.Dtos;
using ExcelDataReader;

namespace EReconciliation.Business.Concrete
{
    public class BaBsReconciliationManager : IBaBsReconciliationService
    {
        private readonly IBaBsReconciliationDal _baBsRecoinciliationDal;
        private readonly ICurrencyAccountService _currencyAccountService;
        private readonly IMailService _mailService;
        private readonly IMailTemplateService _mailTemplateService;
        private readonly IMailParameterService _mailParameterService;

        public BaBsReconciliationManager(IBaBsReconciliationDal baBsRecoinciliationDal, ICurrencyAccountService currencyAccountService, IMailService mailService, IMailTemplateService mailTemplateService, IMailParameterService mailParameterService)
        {
            _baBsRecoinciliationDal = baBsRecoinciliationDal;
            _currencyAccountService = currencyAccountService;
            _mailService = mailService;
            _mailTemplateService = mailTemplateService;
            _mailParameterService = mailParameterService;
        }

        public IResult Add(BaBsReconciliation babsReconciliation)
        {
            string guid = Guid.NewGuid().ToString();
            babsReconciliation.Guid = guid;
            _baBsRecoinciliationDal.Add(babsReconciliation);
            return new SuccessResult(Messages.AddedBaBsReconciliation);
        }

        public IResult AddToExcel(string filePath, int companyId)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using (var stream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        string code = reader.GetString(0);

                        if (code != "Cari Kodu" && code != null)
                        {
                            string type = reader.GetString(1);
                            double mounth = reader.GetDouble(2);
                            double year = reader.GetDouble(3);
                            double quantit = reader.GetDouble(4);
                            double total = reader.GetDouble(5);
                            string guid = Guid.NewGuid().ToString();

                            int currencyAccountId = _currencyAccountService.GetByCode(code, companyId).Data.Id;

                            BaBsReconciliation baBsReconciliation = new BaBsReconciliation()
                            {
                                CompanyId = companyId,
                                CurrencyAccountId = currencyAccountId,
                                Type = type,
                                Mounth = Convert.ToInt16(mounth),
                                Year = Convert.ToInt16(year),
                                Quantity = Convert.ToInt16(quantit),
                                Total = Convert.ToDecimal(total),
                                Guid = guid
                            };

                            _baBsRecoinciliationDal.Add(baBsReconciliation);
                        }
                    }
                }
            }

            File.Delete(filePath);

            return new SuccessResult(Messages.AddedBaBsReconciliation);
        }

        public IResult Update(BaBsReconciliation babsReconciliationn)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(BaBsReconciliation babsReconciliation)
        {
            _baBsRecoinciliationDal.Delete(babsReconciliation);
            return new SuccessResult(Messages.DeletedBaBsReconciliation);
        }

        public IDataResult<BaBsReconciliation> GetById(int id)
        {
            return new SuccessDataResult<BaBsReconciliation>(_baBsRecoinciliationDal.Get(p => p.Id == id));
        }

        public IDataResult<BaBsReconciliation> GetByCode(string code)
        {
            return new SuccessDataResult<BaBsReconciliation>(_baBsRecoinciliationDal.Get(p => p.Guid == code));
        }

        public IDataResult<List<BaBsReconciliation>> GetList(int companyId)
        {
            return new SuccessDataResult<List<BaBsReconciliation>>(_baBsRecoinciliationDal.GetList(p => p.CompanyId == companyId));
        }

        public IDataResult<List<BaBsReconciliation>> GetListByCurrencyAccountId(int currencyAccount)
        {
            return new SuccessDataResult<List<BaBsReconciliation>>(_baBsRecoinciliationDal.GetList(p => p.CurrencyAccountId == currencyAccount));
        }

        public IDataResult<List<BaBsReconciliationDto>> GetListDto(int companyId)
        {
            return new SuccessDataResult<List<BaBsReconciliationDto>>(_baBsRecoinciliationDal.GetAllDto(companyId));
        }

        public IResult SendReconciliationMail(BaBsReconciliationDto babsReconciliationDto)
        {
            throw new NotImplementedException();
        }
    }
}
