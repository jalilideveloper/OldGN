using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IGN.Startup))]
namespace IGN
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
