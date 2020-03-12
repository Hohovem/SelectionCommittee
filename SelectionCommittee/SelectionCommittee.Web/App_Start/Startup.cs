using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using SelectionCommittee.BLL.Interfaces;
using SelectionCommittee.BLL.Services;

[assembly: OwinStartup(typeof(SelectionCommittee.Web.App_Start.Startup))]

namespace SelectionCommittee.Web.App_Start
{
    public class Startup
    {
        IServiceCreator serviceCreator = new ServiceCreator();
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<IUserService>(CreateUserService);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }

        private IUserService CreateUserService()
        {
            //TODO перепроверить строку подключения
            return serviceCreator.CreateUserService("DefaultConnection");
        }
    }
}