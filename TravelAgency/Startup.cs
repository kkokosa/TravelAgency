using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebLearn1.Startup))]
namespace WebLearn1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
