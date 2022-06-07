using EReconciliation.Business.Abstract;
using EReconciliation.Core.Utilities.Results.Abstract;
using EReconciliation.Core.Utilities.Results.Concrete;
using EReconciliation.DataAccess.Abstract;
using EReconciliation.Entities.Concrete;
using EReconciliation.Entities.Dtos;

namespace EReconciliation.Business.Concrete
{
    public class UserReletionShipManager : IUserReletionShipService
    {
        private readonly IUserReletionshipDal _userReletionshipDal;

        public UserReletionShipManager(IUserReletionshipDal userReletionshipDal)
        {
            _userReletionshipDal = userReletionshipDal;
        }

        public void Add(UserReletionship userReletionship)
        {
            _userReletionshipDal.Add(userReletionship);
        }

        public void Delete(UserReletionship userReletionship)
        {
            _userReletionshipDal.Delete(userReletionship);
        }

        public List<UserReletionship> GetList(int userId)
        {
            return _userReletionshipDal.GetList(p => p.UserUserId == userId);
        }

        public IDataResult<UserReletionshipDto> GetById(int userUserId)
        {
            return new SuccessDataResult<UserReletionshipDto>(_userReletionshipDal.GetById(userUserId));
        }

        public IDataResult<List<UserReletionshipDto>> GetListDto(int adminUserId)
        {
            return new SuccessDataResult<List<UserReletionshipDto>>(_userReletionshipDal.GetListDto(adminUserId));
        }

        public void Update(UserReletionship userReletionship)
        {
            _userReletionshipDal.Update(userReletionship);
        }
    }
}
