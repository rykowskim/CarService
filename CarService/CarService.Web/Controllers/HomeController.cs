using CarService.Web.Services.Employee;
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
        
        public HomeController(IEmployeeService empoloyeeService)
        {
            _employeeService = empoloyeeService;
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
                IsVerified = _employeeService.Employees.Where(x => x.User_Id == userId && x.IsActive).FirstOrDefault().IsVerified
            };
            return View(viewModel);
        }
    }
}