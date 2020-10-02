using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SBurkeMIS4200.Startup))]
namespace SBurkeMIS4200
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
