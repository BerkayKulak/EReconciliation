using Microsoft.AspNetCore.Http;

namespace EReconciliation.Entities.Dtos
{
    public class CurrencyAccountExcelDto
    {
        public IFormFile File { get; set; }
        public int CompanyId { get; set; }
    }
}
