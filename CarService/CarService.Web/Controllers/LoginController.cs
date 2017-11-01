using CarService.Data.Models;
using CarService.Web.Mvc.Other;
using CarService.Web.ViewModels.User;
using System;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace CarService.Web.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        [HttpGet, Route("login")]
        public ActionResult Index()
        {
            var viewModel = new LoginViewModel();
            return View("Login", viewModel);
        }

        [HttpPost, Route("login"), ActionName("Index")]
        public ActionResult IndexPost()
        {
            var viewModel = new LoginViewModel();
            if (!TryUpdateModel(viewModel) || !ModelState.IsValid)
            {
                return View(viewModel);
            }

            //var password = Decrypt.DecryptPassword(viewModel.Password);

            var db = new CarServiceContext();
            var user = db.User.Where(x => x.Email.Equals(viewModel.Email) && x.Password.Equals(viewModel.Password)).FirstOrDefault();
            

            if (user == null)
            {
                ModelState.AddModelError("", "Błędny login lub hasło");
                return View("Login", viewModel);
            }

            try
            {
                var identity = new ClaimsIdentity(new[]
                {   
                    new Claim(ClaimTypes.Name, user.Name)
                }, "ApplicationCookie");

                var ctx = Request.GetOwinContext();
                var authManager = ctx.Authentication;

                authManager.SignIn(identity);

                return RedirectToAction("Index", "Home");

            }
            catch(Exception ex)
            {
                return View(viewModel);
            }                                             
        }

        public ActionResult Signout()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("Index", "Home");
        }
    }
}