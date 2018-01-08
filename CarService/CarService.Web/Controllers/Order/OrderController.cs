using CarService.Web.Services.Car;
using CarService.Web.Services.Cost;
using CarService.Web.Services.Employee;
using CarService.Web.Services.Order;
using System.Web.Mvc;

namespace CarService.Web.Controllers.Order
{
    public partial class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ICarsService _carService;
        private readonly IEmployeeService _employeeService;
        private readonly ICostService _costService;

        public OrderController(IOrderService orderService,
            ICarsService carService,
            IEmployeeService employeeService,
            ICostService costService)
        {
            _orderService = orderService;
            _carService = carService;
            _employeeService = employeeService;
            _costService = costService;
        }
    }
}