using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ISA_TWAAOS.Startup))]
namespace ISA_TWAAOS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
