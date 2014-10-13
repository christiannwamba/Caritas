using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Caritas.Startup))]
namespace Caritas
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
