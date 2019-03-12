using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LMCStore.Startup))]
namespace LMCStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
