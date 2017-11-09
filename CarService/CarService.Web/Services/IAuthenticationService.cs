namespace CarService.Web.Services
{
    public interface IAuthenticationService
    {
        void SignIn(Data.Models.User user);
    }
}