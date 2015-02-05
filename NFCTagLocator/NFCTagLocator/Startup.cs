using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NFCTagLocator.Startup))]
namespace NFCTagLocator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
