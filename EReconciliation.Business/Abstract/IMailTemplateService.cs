﻿using EReconciliation.Core.Utilities.Results.Abstract;
using EReconciliation.Entities.Concrete;

namespace EReconciliation.Business.Abstract
{
    public interface IMailTemplateService
    {
        IResult Add(MailTemplate mailTemplate);
        IResult Update(MailTemplate mailTemplate);
        IResult Delete(MailTemplate mailTemplate);
        IDataResult<MailTemplate> Get(int id);
        IDataResult<MailTemplate> GetByTemplateName(string name, int companyId);
        IDataResult<List<MailTemplate>> GetAll(int companyId);
    }
}
