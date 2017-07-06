using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MagicWebsite.Startup))]
namespace MagicWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
