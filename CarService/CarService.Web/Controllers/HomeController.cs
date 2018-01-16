using CarService.Web.Services.Employee;
using CarService.Web.Services.Order;
using CarService.Web.ViewModels.Home;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;

namespace CarService.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IOrderService _orderService;
        
        public HomeController(IEmployeeService empoloyeeService,
            IOrderService orderService)
        {
            _employeeService = empoloyeeService;
            _orderService = orderService;
        }
        //[HttpGet, Route("Home")]
        public ActionResult Index()
        {
            var identity = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            var userId = int.Parse(claims.Where(x => x.Type == "Id").Select(w => w.Value).FirstOrDefault());

            var viewModel = new StartPageViewModel
            {
                UserName = User.Identity.Name,
                IsVerified = _employeeService.Employees.Where(x => x.User_Id == userId && x.IsActive).FirstOrDefault().IsVerified,
                OrderItems = _orderService.Orders.OrderByDescending(x => x.ModifyDate).Take(6).Select(n => new OrderItem
                {
                    OrderId = n.Id,
                    CustomerId = n.Customer.Id,
                    Customer = string.Format("{0} {1}", n.Customer.Name, n.Customer.Surname),
                    Car = string.Format("{0} {1}", n.Car.Mark, n.Car.Model),
                    OrderType = n.OrderType.Name,
                    OrderStatus = n.OrderStatus.Name,
                    EmployeeId = n.Employee.Id,
                    Employee = string.Format("{0} {1}", n.Employee.Name, n.Employee.Surname)
                })
            };
            return View(viewModel);
        }
    }
}