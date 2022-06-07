using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using EReconciliation.Core.CrossCuttingConcerns.Caching;
using EReconciliation.Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace EReconciliation.Core.Aspects.Caching
{
    public class CacheRemoveAspect : MethodInterception
    {
        private string _pattern;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
