using Castle.Core.Interceptor;
using IInterceptor = Microsoft.EntityFrameworkCore.Diagnostics.IInterceptor;

namespace EReconciliation.Core.Utilities.Interceptors
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; }
        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}
