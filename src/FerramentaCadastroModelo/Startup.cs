using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FerramentaCadastroModelo.Startup))]
namespace FerramentaCadastroModelo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
