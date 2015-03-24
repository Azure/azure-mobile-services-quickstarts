using Microsoft.Azure.Mobile.Server.Config;
using System.Web.Http;

namespace TryMobileApps
{
    public class CustomOwinAppBuilder : OwinAppBuilder
    {
        public CustomOwinAppBuilder(HttpConfiguration config) : base(config) { }

        protected override void ConfigureBackstop(Owin.IAppBuilder appBuilder, HttpConfiguration config)
        {
            // The default ConfigureBackstop method prevents any default HttpHandlers from executing, i.e. static content
            //base.ConfigureBackstop(appBuilder, config);
        }
    }
}
