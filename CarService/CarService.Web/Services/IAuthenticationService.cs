using CarService.Web.ViewModels.User;

namespace CarService.Web.Services
{
    public interface IAuthenticationService
    {
        void SignIn(Data.Models.User user);
        int GetAuthenticatedUser();
    }
}