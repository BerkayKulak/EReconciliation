using EReconciliation.Core.Entities;

namespace EReconciliation.Entities.Concrete
{
    public class TermsandCondition : IEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
