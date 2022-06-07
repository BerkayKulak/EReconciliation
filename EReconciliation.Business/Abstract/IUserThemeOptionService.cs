using EReconciliation.Core.Utilities.Results.Abstract;
using EReconciliation.Entities.Concrete;

namespace EReconciliation.Business.Abstract
{
    public interface IUserThemeOptionService
    {
        IResult Update(UserThemeOption userThemeOption);
        void Delete(UserThemeOption userThemeOption);
        IDataResult<UserThemeOption> GetByUserId(int userId);
    }
}
