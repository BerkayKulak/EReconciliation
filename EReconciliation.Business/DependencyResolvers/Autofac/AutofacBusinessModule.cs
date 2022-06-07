using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using EReconciliation.Business.Abstract;
using EReconciliation.Business.Concrete;
using EReconciliation.Core.Utilities.Interceptors;
using EReconciliation.Core.Utilities.Security.JWT;
using EReconciliation.DataAccess.Abstract;
using EReconciliation.DataAccess.Concrete.EntityFramework;

namespace EReconciliation.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CompanyManager>().As<ICompanyService>();
            builder.RegisterType<EfCompanyDal>().As<ICompanyDal>();

            builder.RegisterType<AccountReconciliationDetailManager>().As<IAccountReconciliationDetailService>();
            builder.RegisterType<EfAccountReconciliationDetailDal>().As<IAccountReconciliationDetailDal>();

            builder.RegisterType<AccountReconciliationManager>().As<IAccountReconciliationService>();
            builder.RegisterType<EfAccountReconciliationDal>().As<IAccountReconciliationDal>();

            builder.RegisterType<BaBsReconciliationManager>().As<IBaBsReconciliationService>();
            builder.RegisterType<EfBaBsRecoinciliationDal>().As<IBaBsReconciliationDal>();

            builder.RegisterType<BaBsReconciliationDetailManager>().As<IBaBsReconciliationDetailService>();
            builder.RegisterType<EfBaBsReconciliationDetailDal>().As<IBaBsReconciliationDetailDal>();

            builder.RegisterType<CurrencyAccountManager>().As<ICurrencyAccountService>();
            builder.RegisterType<EfCurrencyAccountDal>().As<ICurrencyAccountDal>();

            builder.RegisterType<CurrencyManager>().As<ICurrencyService>();
            builder.RegisterType<EfCurrencyDal>().As<ICurrencyDal>();

            builder.RegisterType<MailParameterManager>().As<IMailParameterService>();
            builder.RegisterType<EfMailParameterDal>().As<IMailParameterDal>();

            builder.RegisterType<MailTemplateManager>().As<IMailTemplateService>();
            builder.RegisterType<EfMailTemplateDal>().As<IMailTemplateDal>();

            builder.RegisterType<MailManager>().As<IMailService>();
            builder.RegisterType<EfMailDal>().As<IMailDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<TermsandConditionManager>().As<ITermsandConditionService>();
            builder.RegisterType<EfTermsandConditionDal>().As<ITermsandConditionDal>();

            builder.RegisterType<UserThemeOptionManager>().As<IUserThemeOptionService>();
            builder.RegisterType<EfUserThemeOptionDal>().As<IUserThemeOptionDal>();

            builder.RegisterType<OperationClaimManager>().As<IOperationClaimService>();
            builder.RegisterType<EfOperationClaimDal>().As<IOperationClaimDal>();

            builder.RegisterType<ForgotPasswordManager>().As<IForgotPasswordService>();
            builder.RegisterType<EfForgotPasswordDal>().As<IForgotPasswordDal>();

            builder.RegisterType<UserOperationClaimManager>().As<IUserOperationClaimService>();
            builder.RegisterType<EfUserOperationClaimDal>().As<IUserOperationClaimDal>();

            builder.RegisterType<UserReletionShipManager>().As<IUserReletionShipService>();
            builder.RegisterType<EfUserReletionShipDal>().As<IUserReletionshipDal>();

            builder.RegisterType<UserCompanyManager>().As<IUserCompanyService>();
            builder.RegisterType<EfUserCompanyDal>().As<IUserCompanyDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();
        }
    }
}
