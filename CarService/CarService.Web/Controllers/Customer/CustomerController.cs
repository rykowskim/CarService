using CarService.Web.Services.Customer;
using System.Web.Mvc;

namespace CarService.Web.Controllers.Customer
{
    public partial class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
    }
}