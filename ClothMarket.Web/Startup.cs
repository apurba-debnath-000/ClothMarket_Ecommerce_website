using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClothMarket.Web.Startup))]
namespace ClothMarket.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
