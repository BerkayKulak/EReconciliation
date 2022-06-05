using EReconciliation.Core.Utilities.Results.Abstract;

namespace EReconciliation.Business.Abstract
{
    public interface IMailService
    {
        IResult SendMail(string mail, string subject, string body);
    }
}
