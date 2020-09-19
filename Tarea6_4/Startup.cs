using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tarea6_4.Startup))]
namespace Tarea6_4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
