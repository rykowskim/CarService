using CarService.Web.Services.Address;
using CarService.Web.Services.Employee;
using CarService.Web.Services.Position;
using CarService.Web.Services.User;
using System.Web.Mvc;

namespace CarService.Web.Controllers.Employee
{
    public partial class EmployeeController : Controller
    {
        private readonly IPositionService _postionService;
        private readonly IUserService _userService;
        private readonly IEmployeeService _employeeService;
        private readonly IAddressService _addressService;
        
        public EmployeeController(IPositionService positionService,
            IUserService userService,
            IEmployeeService employeeService,
            IAddressService addressService)
        {
            _postionService = positionService;
            _userService = userService;
            _employeeService = employeeService;
            _addressService = addressService;
        }
    }
}