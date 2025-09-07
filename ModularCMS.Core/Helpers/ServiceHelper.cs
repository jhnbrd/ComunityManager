using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularCMS.Core.Helpers
{
    public static class ServiceHelper
    {
        private static IServiceProvider? _serviceProvider;

        public static void Initialize(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public static T GetService<T>() where T : notnull
        {
            if (_serviceProvider == null)
                throw new InvalidOperationException("ServiceProvider not initialized. Call ServiceHelper.Initialize() in MauiProgram.cs");

            return _serviceProvider.GetRequiredService<T>();
        }
    }
}
