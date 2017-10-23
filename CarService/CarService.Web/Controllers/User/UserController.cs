using CarService.Data.Services.User;
using CarService.Web.ViewModels.User;
using System.Web.Mvc;

namespace CarService.Web.Controllers.User
{
    public partial class UserController : Controller
    {
        private readonly IUserService _userService; 

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
    }
}