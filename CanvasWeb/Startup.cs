using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CanvasWeb.Startup))]
namespace CanvasWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
