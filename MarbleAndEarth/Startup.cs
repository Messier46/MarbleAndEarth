using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MarbleAndEarth.Startup))]
namespace MarbleAndEarth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
