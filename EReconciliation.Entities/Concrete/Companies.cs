using EReconciliation.Core.Entities;

namespace EReconciliation.Entities.Concrete
{
    public class Companies : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string TaxDepartment { get; set; }
        public string? TaxIdNumber { get; set; }
        public string? IdentityNumber { get; set; }
        public DateTime AddedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
