using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ElJournal.Startup))]
namespace ElJournal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
