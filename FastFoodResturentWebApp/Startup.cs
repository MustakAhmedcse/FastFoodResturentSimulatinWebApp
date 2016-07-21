using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FastFoodResturentWebApp.Startup))]
namespace FastFoodResturentWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
