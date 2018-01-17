using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ans.Startup))]
namespace ans
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
