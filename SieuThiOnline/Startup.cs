using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SieuThiOnline.Startup))]
namespace SieuThiOnline
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
