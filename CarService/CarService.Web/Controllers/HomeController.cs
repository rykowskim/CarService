using CarService.Web.ViewModels.Home;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;

namespace CarService.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var identity = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            var surname = claims.Where(x => x.Type == ClaimTypes.Surname).Select(w => w.Value).FirstOrDefault();
            var viewModel = new StartPageViewModel { UserName = User.Identity.Name };
            return View(viewModel);
        }
    }
}