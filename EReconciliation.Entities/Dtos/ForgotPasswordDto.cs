using EReconciliation.Core.Entities;

namespace EReconciliation.Entities.Dtos
{
    public class ForgotPasswordDto : IDto
    {
        public string Value { get; set; }
        public string Password { get; set; }
    }
}
