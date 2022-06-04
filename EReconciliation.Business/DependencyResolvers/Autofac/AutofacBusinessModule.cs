using Autofac;
using EReconciliation.Business.Abstract;
using EReconciliation.Business.Concrete;
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
        }
    }
}
