using EReconciliation.Business.Abstract;
using EReconciliation.Business.BusinessAcpects;
using EReconciliation.Business.Constants;
using EReconciliation.Core.Aspects.Caching;
using EReconciliation.Core.Aspects.Performance;
using EReconciliation.Core.Utilities.Results.Abstract;
using EReconciliation.Core.Utilities.Results.Concrete;
using EReconciliation.DataAccess.Abstract;
using EReconciliation.Entities.Concrete;

namespace EReconciliation.Business.Concrete
{
    public class MailTemplateManager : IMailTemplateService
    {
        private readonly IMailTemplateDal _mailTemplateDal;

        public MailTemplateManager(IMailTemplateDal mailTemplateDal)
        {
            _mailTemplateDal = mailTemplateDal;
        }

        [PerformanceAspect(3)]
        [SecuredOperation("MailTemplate.Add,Admin")]
        [CacheRemoveAspect("IMailTemplateService.Get")]
        public IResult Add(MailTemplate mailTemplate)
        {
            _mailTemplateDal.Add(mailTemplate);
            return new SuccessResult(Messages.MailTemplateAdded);
        }

        [PerformanceAspect(3)]
        [SecuredOperation("MailTemplate.Delete,Admin")]
        [CacheRemoveAspect("IMailTemplateService.Get")]
        public IResult Delete(MailTemplate mailTemplate)
        {
            _mailTemplateDal.Delete(mailTemplate);
            return new SuccessResult(Messages.MailTemplateDeleted);
        }

        [PerformanceAspect(3)]
        [CacheAspect(60)]
        public IDataResult<MailTemplate> Get(int id)
        {
            return new SuccessDataResult<MailTemplate>(_mailTemplateDal.Get(m => m.Id == id));
        }

        [PerformanceAspect(3)]
        [SecuredOperation("MailTemplate.GetList,Admin")]
        [CacheAspect(60)]
        public IDataResult<List<MailTemplate>> GetAll(int companyId)
        {
            return new SuccessDataResult<List<MailTemplate>>(_mailTemplateDal.GetList(m => m.CompanyId == companyId));
        }

        public IDataResult<MailTemplate> GetByCompanyId(int companyId)
        {
            return new SuccessDataResult<MailTemplate>(_mailTemplateDal.Get(m => m.CompanyId == companyId));
        }

        [CacheAspect(60)]
        public IDataResult<MailTemplate> GetByTemplateName(string name, int companyId)
        {
            return new SuccessDataResult<MailTemplate>(_mailTemplateDal.Get(m => m.Type == name && m.CompanyId == companyId));
        }

        [PerformanceAspect(3)]
        [SecuredOperation("MailTemplate.Update,Admin")]
        [CacheRemoveAspect("IMailTemplateService.Get")]
        public IResult Update(MailTemplate mailTemplate)
        {
            var result = _mailTemplateDal.Get(p => p.CompanyId == mailTemplate.CompanyId);
            if (result != null)
            {
                _mailTemplateDal.Update(mailTemplate);
            }
            else
            {
                mailTemplate.Id = 0;
                _mailTemplateDal.Add(mailTemplate);
            }
            return new SuccessResult(Messages.MailTemplateUpdated);
        }
    }
}
