using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_BierenSecurity.Startup))]
namespace MVC_BierenSecurity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
