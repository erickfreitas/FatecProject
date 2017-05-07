using Microsoft.Owin;
using Owin;
using Project.MVC;

[assembly: OwinStartup(typeof(Startup))]

namespace Project.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
