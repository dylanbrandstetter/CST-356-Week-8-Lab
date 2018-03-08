using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CST356_Week_5_Lab.Startup))]
namespace CST356_Week_5_Lab
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
