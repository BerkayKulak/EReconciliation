using EReconciliation.Core.Entities.Concrete;
using EReconciliation.Core.Utilities.Results.Abstract;
using EReconciliation.Entities.Concrete;

namespace EReconciliation.Business.Abstract
{
    public interface IForgotPasswordService
    {
        IDataResult<ForgotPassword> CreateForgotPassword(User user);
        IDataResult<List<ForgotPassword>> GetListByUserId(int userId);
        ForgotPassword GetForgotPassword(string value);
        void Update(ForgotPassword forgotPassword);
    }
}
