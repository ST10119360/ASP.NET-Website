using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(iwish.Startup))]
namespace iwish
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
