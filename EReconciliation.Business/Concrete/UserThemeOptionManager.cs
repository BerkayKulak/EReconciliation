using EReconciliation.Business.Abstract;
using EReconciliation.Business.Constants;
using EReconciliation.Core.Utilities.Results.Abstract;
using EReconciliation.Core.Utilities.Results.Concrete;
using EReconciliation.DataAccess.Abstract;
using EReconciliation.Entities.Concrete;

namespace EReconciliation.Business.Concrete
{
    public class UserThemeOptionManager : IUserThemeOptionService
    {
        private readonly IUserThemeOptionDal _userThemeOptionDal;

        public UserThemeOptionManager(IUserThemeOptionDal userThemeOptionDal)
        {
            _userThemeOptionDal = userThemeOptionDal;
        }

        public void Delete(UserThemeOption userThemeOption)
        {
            _userThemeOptionDal.Delete(userThemeOption);
        }

        public IDataResult<UserThemeOption> GetByUserId(int userId)
        {
            return new SuccessDataResult<UserThemeOption>(_userThemeOptionDal.Get(p => p.UserId == userId));
        }

        public IResult Update(UserThemeOption userThemeOption)
        {
            var result = _userThemeOptionDal.Get(p => p.UserId == userThemeOption.UserId);
            if (result == null)
            {
                userThemeOption.Id = 0;
                _userThemeOptionDal.Add(userThemeOption);
            }
            else
            {
                _userThemeOptionDal.Update(userThemeOption);
            }
            return new SuccessResult(Messages.UpdatedUserTheme);
        }
    }
}
