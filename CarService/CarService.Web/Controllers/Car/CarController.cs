using CarService.Web.Services.Car;
using CarService.Web.Services.Customer;
using System.Web.Mvc;

namespace CarService.Web.Controllers.Car
{
    public partial class CarController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly ICarsService _carService; 
        
        public CarController(ICustomerService customerService,
            ICarsService carService)
        {
            _customerService = customerService;
            _carService = carService;
        }
    }
}