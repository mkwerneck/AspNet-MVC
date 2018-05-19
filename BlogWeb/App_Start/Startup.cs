using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Microsoft.Owin;
using BlogWeb.Infra;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using BlogWeb.Models;

namespace BlogWeb.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder builder)
        {
            var options = new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Autenticacao/Login")
            };
            builder.UseCookieAuthentication(options);

            builder.CreatePerOwinContext<BlogContext>(
                () => new BlogContext()
            );

            builder.CreatePerOwinContext<IUserStore<Usuario>>(
                (opt, owinContext) =>
                {
                    var context = owinContext.Get<BlogContext>();
                    return new UserStore<Usuario>(context);
                }
            );

            builder.CreatePerOwinContext<UserManager<Usuario>>(
                (opt, owinContext) =>
                {
                    var store = owinContext.Get<IUserStore<Usuario>>();
                    return new UserManager<Usuario>(store);
                }
            );
        }
    }
}