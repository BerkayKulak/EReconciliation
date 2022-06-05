using EReconciliation.Core.Utilities.Results.Abstract;
using EReconciliation.Entities.Dtos;

namespace EReconciliation.Business.Abstract
{
    public interface IMailService
    {
        IResult SendMail(SendMailDto sendMailDto);
    }
}
