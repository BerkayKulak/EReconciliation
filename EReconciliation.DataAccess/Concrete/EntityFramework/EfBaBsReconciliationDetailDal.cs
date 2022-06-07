using EReconciliation.Core.DataAccess.EntityFrameowork;
using EReconciliation.DataAccess.Abstract;
using EReconciliation.DataAccess.Concrete.EntityFramework.Context;
using EReconciliation.Entities.Concrete;
using EReconciliation.Entities.Dtos;

namespace EReconciliation.DataAccess.Concrete.EntityFramework
{
    public class EfBaBsReconciliationDetailDal : EfEntityRepositoryBase<BaBsReconciliationDetail, ContextDb>, IBaBsReconciliationDetailDal
    {
        public List<BaBsReconciliationDto> GetAllDto(int companyId)
        {
            using (var context = new ContextDb())
            {
                var result = from recoinciliation in context.BaBsReconciliations.Where(p => p.CompanyId == companyId)
                             join company in context.Companies on recoinciliation.CompanyId equals company.Id
                             join account in context.CurrencyAccounts on recoinciliation.CurrencyAccountId equals account.Id
                             select new BaBsReconciliationDto
                             {
                                 CompanyId = companyId,
                                 CurrencyAccountId = account.Id,
                                 AccountIdentityNumber = account.IdentityNumber,
                                 AccountName = account.Name,
                                 AccountTaxDepartment = account.TaxDepartment,
                                 AccountTaxIdNumber = account.TaxIdNumber,
                                 CompanyIdentityNumber = company.IdentityNumber,
                                 CompanyName = company.Name,
                                 CompanyTaxDepartment = company.TaxDepartment,
                                 CompanyTaxIdNumber = company.TaxIdNumber,
                                 Total = recoinciliation.Total,
                                 EmailReadDate = recoinciliation.EmailReadDate,
                                 Guid = recoinciliation.Guid,
                                 Id = recoinciliation.Id,
                                 IsEmailRead = recoinciliation.IsEmailRead,
                                 IsResultSucceed = recoinciliation.IsResultSucceed,
                                 IsSendEmail = recoinciliation.IsSendEmail,
                                 ResultDate = recoinciliation.ResultDate,
                                 ResultNote = recoinciliation.ResultNote,
                                 SendEmailDate = recoinciliation.SendEmailDate,
                                 CurrencyCode = "TL",
                                 AccountEmail = account.Email,
                                 Mounth = recoinciliation.Mounth,
                                 Type = recoinciliation.Type,
                                 Quantity = recoinciliation.Quantity,
                                 Year = recoinciliation.Year
                             };

                return result.ToList();
            }
        }
    }
}
