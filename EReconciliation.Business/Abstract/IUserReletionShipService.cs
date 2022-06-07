using EReconciliation.Core.Utilities.Results.Abstract;
using EReconciliation.Entities.Concrete;
using EReconciliation.Entities.Dtos;

namespace EReconciliation.Business.Abstract
{
    public interface IUserReletionShipService
    {
        void Add(UserReletionship userReletionship);
        void Update(UserReletionship userReletionship);
        void Delete(UserReletionship userReletionship);
        IDataResult<List<UserReletionshipDto>> GetListDto(int adminUserId);
        IDataResult<UserReletionshipDto> GetById(int userUserId);
        List<UserReletionship> GetList(int userId);
    }
}
