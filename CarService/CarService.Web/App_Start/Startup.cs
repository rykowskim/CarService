using Owin;

namespace CarService.Web.App_Start
{
    public class Startup
    {
        public void Configuration (IAppBuilder app)
        {
            app.UseCookieAuthentication(new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new Microsoft.Owin.PathString("/login")
            });
        }
    }
}