using CarService.Web.Services.Employee;
using CarService.Web.Services.User;
using System.Web.Mvc;

namespace CarService.Web.Controllers.User
{
    public partial class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IEmployeeService _employeeService;
        
        public UserController(IUserService userService,
            IEmployeeService employeeService)
        {
            _userService = userService;
            _employeeService = employeeService;
        }

        
    }
}