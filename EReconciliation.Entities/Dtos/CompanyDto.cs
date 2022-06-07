using EReconciliation.Core.Entities;
using EReconciliation.Entities.Concrete;

namespace EReconciliation.Entities.Dtos
{
    public class CompanyDto : Company, IDto
    {
        public Company Company { get; set; }
        public int UserId { get; set; }
    }
}
