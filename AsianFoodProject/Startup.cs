using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AsianFoodProject.Startup))]
namespace AsianFoodProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
