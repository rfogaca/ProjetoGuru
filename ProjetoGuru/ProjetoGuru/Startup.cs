using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjetoGuru.Startup))]
namespace ProjetoGuru
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
