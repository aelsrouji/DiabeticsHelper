using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DiabeticsHelper.Startup))]
namespace DiabeticsHelper
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
