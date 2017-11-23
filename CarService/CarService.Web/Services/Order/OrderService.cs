using CarService.Web.Services.Car;
using CarService.Web.Services.Customer;
using CarService.Web.Services.Employee;

namespace CarService.Web.Services.Order
{
    public partial class OrderService : IOrderService
    {
        private readonly ICustomerService _customerService;
        private readonly IEmployeeService _employeeService;
        private readonly ICarsService _carService;

        public OrderService(ICustomerService customerService,
            IEmployeeService employeeService,
            ICarsService carService)
        {
            _customerService = customerService;
            _employeeService = employeeService;
            _carService = carService;
        }
    }
}