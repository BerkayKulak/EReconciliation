using EReconciliation.Entities.Concrete;

namespace EReconciliation.Entities.Dtos
{
    public class UserAndCompanyRegisterDto
    {
        public UserForRegister UserForRegister { get; set; }
        public Company Company { get; set; }
    }
}
