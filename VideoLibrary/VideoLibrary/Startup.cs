using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VideoLibrary.Startup))]
namespace VideoLibrary
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
