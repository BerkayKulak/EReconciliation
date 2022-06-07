using EReconciliation.Core.DataAccess;
using EReconciliation.Entities.Concrete;
using EReconciliation.Entities.Dtos;

namespace EReconciliation.DataAccess.Abstract
{
    public interface IBaBsReconciliationDal : IEntityRepository<BaBsReconciliation>
    {
        List<BaBsReconciliationDto> GetAllDto(int companyId);
    }
}
