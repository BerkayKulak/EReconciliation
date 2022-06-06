using EReconciliation.Core.Entities;

namespace EReconciliation.Entities.Concrete
{
    public class MailTemplate : IEntity
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
    }
}
