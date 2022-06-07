using EReconciliation.Business.Abstract;
using EReconciliation.Core.Entities.Concrete;
using EReconciliation.Core.Utilities.Results.Abstract;
using EReconciliation.Core.Utilities.Results.Concrete;
using EReconciliation.DataAccess.Abstract;
using EReconciliation.Entities.Concrete;

namespace EReconciliation.Business.Concrete
{
    public class ForgotPasswordManager : IForgotPasswordService
    {
        private readonly IForgotPasswordDal _forgotPasswordDal;

        public ForgotPasswordManager(IForgotPasswordDal forgotPasswordDal)
        {
            _forgotPasswordDal = forgotPasswordDal;
        }

        public IDataResult<ForgotPassword> CreateForgotPassword(User user)
        {
            ForgotPassword forgotPassword = new ForgotPassword()
            {
                IsActive = true,
                SendDate = DateTime.Now,
                UserId = user.Id,
                Value = Guid.NewGuid().ToString()
            };
            _forgotPasswordDal.Add(forgotPassword);
            return new SuccessDataResult<ForgotPassword>(forgotPassword);
        }

        public ForgotPassword GetForgotPassword(string value)
        {
            return _forgotPasswordDal.Get(p => p.Value == value);
        }

        public IDataResult<List<ForgotPassword>> GetListByUserId(int userId)
        {
            return new SuccessDataResult<List<ForgotPassword>>(_forgotPasswordDal.GetList(p => p.UserId == userId && p.IsActive == true));
        }

        public void Update(ForgotPassword forgotPassword)
        {
            _forgotPasswordDal.Update(forgotPassword);
        }
    }
}
