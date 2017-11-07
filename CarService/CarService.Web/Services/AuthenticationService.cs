using CarService.Web.Services.User;
using CarService.Web.ViewModels.User;
using System.Security.Claims;
using System.Web;

namespace CarService.Web.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserService _userService;
        private readonly ClaimsIdentity _claimIdentity;

        public AuthenticationService(IUserService userService)
        {
            _userService = userService;
        }

        public void SignIn(Data.Models.User user)
        {
            var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim("Id", user.Id.ToString())
                }, "ApplicationCookie");
            
            var ctx = HttpContext.Current.Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignIn(identity);
        }

        public int GetAuthenticatedUser()
        {
            //var userId = ((ClaimsIdentity)User.Identity).FindFirst("Id").Value;
            var userId = int.Parse(_claimIdentity.FindFirst("Id").Value);
            return userId;
        }
    }
}