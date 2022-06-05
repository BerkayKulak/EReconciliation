using EReconciliation.Entities.Dtos;

namespace EReconciliation.DataAccess.Abstract
{
    public interface IMailDal
    {
        void SendMail(SendMailDto sendMailDto);
    }
}
