﻿using EReconciliation.Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace EReconciliation.Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();
        }
    }
}
