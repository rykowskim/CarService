using CarService.Web.ViewModels.User;
using System.Web.Mvc;

namespace CarService.Web.Controllers.User
{
    public class UserController : Controller
    {
        // GET: Register
        [HttpGet, Route("User/Register")]
        public ActionResult Register()
        {
            var viewModel = new RegisterCreateViewModel();
            return View(viewModel);
        }

        [HttpPost, Route("User/Register"), ActionName("Register"), ValidateAntiForgeryToken]
        public ActionResult RegisterPost()
        {
            var viewModel = new RegisterCreateViewModel();
            if (!TryUpdateModel(viewModel) || !ModelState.IsValid)
            {
                return View();
            }
            return View(viewModel);
        }
    }
}