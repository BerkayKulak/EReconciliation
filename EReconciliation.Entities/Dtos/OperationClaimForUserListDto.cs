using EReconciliation.Core.Entities;

namespace EReconciliation.Entities.Dtos
{
    public class OperationClaimForUserListDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public string UserName { get; set; }
    }
}
