using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SelectionCommittee.Web.Startup))]
namespace SelectionCommittee.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
