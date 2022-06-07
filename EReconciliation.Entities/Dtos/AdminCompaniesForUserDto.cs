using EReconciliation.Core.Entities;
using EReconciliation.Entities.Concrete;

namespace EReconciliation.Entities.Dtos
{
    public class AdminCompaniesForUserDto : Company, IDto
    {
        public bool IsTrue { get; set; }
    }
}
