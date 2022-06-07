using EReconciliation.Core.DataAccess;
using EReconciliation.Entities.Concrete;
using EReconciliation.Entities.Dtos;

namespace EReconciliation.DataAccess.Abstract
{
    public interface IUserReletionshipDal : IEntityRepository<UserReletionship>
    {
        List<UserReletionshipDto> GetListDto(int adminUserId);
        UserReletionshipDto GetById(int userUserId);
    }
}
