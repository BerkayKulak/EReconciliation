using EReconciliation.Core.DataAccess.EntityFrameowork;
using EReconciliation.Core.Entities.Concrete;
using EReconciliation.DataAccess.Abstract;
using EReconciliation.DataAccess.Concrete.EntityFramework.Context;
using EReconciliation.Entities.Concrete;

namespace EReconciliation.DataAccess.Concrete.EntityFramework
{
    public class EfCompanyDal : EfEntityRepositoryBase<Company, ContextDb>, ICompanyDal
    {
        public void UserCompanyAdd(int userId, int companyId)
        {
            using (var context = new ContextDb())
            {
                UserCompany userCompany = new UserCompany()
                {
                    UserId = userId,
                    CompanyId = companyId,
                    AddedAt = DateTime.Now,
                    IsActive = true
                };
                context.UserCompanies.Add(userCompany);
                context.SaveChanges();
            }
        }

        public UserCompany GetCompany(int userId)
        {
            using (var context = new ContextDb())
            {
                var result = context.UserCompanies.Where(p => p.UserId == userId).FirstOrDefault();
                return result;
            }
        }
    }
}
