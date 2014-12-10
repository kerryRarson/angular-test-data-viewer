using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OPI.HHS.Insight.Startup))]
namespace OPI.HHS.Insight
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
