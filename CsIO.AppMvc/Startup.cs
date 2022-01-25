using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CsIO.AppMvc.Startup))]
namespace CsIO.AppMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
