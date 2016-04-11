using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SeekAsk.WebSites.Startup))]
namespace SeekAsk.WebSites
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
