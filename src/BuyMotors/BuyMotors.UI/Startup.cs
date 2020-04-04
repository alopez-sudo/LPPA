using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BuyMotors.Startup))]
namespace BuyMotors
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
