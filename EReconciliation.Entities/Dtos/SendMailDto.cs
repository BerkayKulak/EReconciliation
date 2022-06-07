using EReconciliation.Core.Entities;
using EReconciliation.Entities.Concrete;

namespace EReconciliation.Entities.Dtos
{
    public class SendMailDto : IDto
    {
        public MailParameter mailParameter { get; set; }
        public string email { get; set; }
        public string subject { get; set; }
        public string body { get; set; }
    }
}

