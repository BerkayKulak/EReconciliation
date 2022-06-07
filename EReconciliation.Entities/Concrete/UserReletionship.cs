using EReconciliation.Core.Entities;

namespace EReconciliation.Entities.Concrete
{
    public class UserReletionship : IEntity
    {
        public int Id { get; set; }
        public int AdminUserId { get; set; }
        public int UserUserId { get; set; }
    }
}
