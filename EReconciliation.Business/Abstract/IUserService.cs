using EReconciliation.Core.Entities.Concrete;

namespace EReconciliation.Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user, int companyId);
        void Add(User user);
        void Update(User user);
        User GetById(int id);
        User GetByMail(string email);
        User GetByMailConfirmValue(string value);
    }
}
