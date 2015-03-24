using Microsoft.Azure.Mobile.Server.Config;
using System;
using System.Collections.Generic;
using System.Web.Http;

[assembly: HostConfigProvider(typeof(TryMobileApps.CustomConfigProvider))]

namespace TryMobileApps
{
    public class CustomConfigProvider : HostConfigProvider
    {
        protected override IDictionary<Type, object> GetServices(HttpConfiguration config)
        {
            // change the dependency resolver configuration to use our custom Owin configuration
            var services = base.GetServices(config);
            services[typeof(IOwinAppBuilder)] = new CustomOwinAppBuilder(config);
            return services;
        }
    }
}