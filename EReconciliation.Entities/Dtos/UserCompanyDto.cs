using EReconciliation.Core.Entities.Concrete;

namespace EReconciliation.Entities.Dtos
{
    public class UserCompanyDto : User
    {
        public int CompanyId { get; set; }
    }
}
