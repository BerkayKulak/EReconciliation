using Microsoft.Extensions.DependencyInjection;

namespace EReconciliation.Core.Utilities.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection services);
    }
}
