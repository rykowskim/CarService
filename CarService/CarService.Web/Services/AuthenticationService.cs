using CarService.Web.Services.User;
using System.Security.Claims;
using System.Web;

namespace CarService.Web.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserService _userService;
        public AuthenticationService(IUserService userService)
        {
            _userService = userService;
        }

        public void SignIn(Data.Models.User user)
        {
            var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Surname, user.Surname),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim("Id", user.Id.ToString())
                }, "ApplicationCookie");
            
            var ctx = HttpContext.Current.Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignIn(identity);

            
        }

        //public Au GetAuthenticatedUser()
        //{
        //    _authenticatedUser.Id = int.Parse(_claimIdentity.FindFirst("Id").Value);
        //    _authenticatedUser.Name = _claimIdentity.Name;
        //    return _authenticatedUser;
        //}
    }
}