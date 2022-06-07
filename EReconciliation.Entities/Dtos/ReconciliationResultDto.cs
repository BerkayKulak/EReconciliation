using EReconciliation.Core.Entities;

namespace EReconciliation.Entities.Dtos
{
    public class ReconciliationResultDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public bool Result { get; set; }
    }
}
