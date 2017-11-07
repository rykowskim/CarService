using System.Security.Claims;
using System.Web.Mvc;

namespace CarService.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var id = ((ClaimsIdentity)User.Identity).FindFirst("Id").Value;
            return View();
        }
    }
}