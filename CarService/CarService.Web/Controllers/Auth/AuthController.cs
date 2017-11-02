using CarService.Data.Models;
using CarService.Web.Mvc.Other;
using CarService.Web.Services;
using CarService.Web.Services.User;
using CarService.Web.ViewModels.User;
using System;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace CarService.Web.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAuthenticationService _authenticationService;

        public AuthController(IUserService userService,
            IAuthenticationService authenticationService)
        {
            _userService = userService;
            _authenticationService = authenticationService;
        }

        [HttpGet, Route("auth/login")]
        public ActionResult Login()
        {
            var viewModel = new LoginViewModel();
            return View(viewModel);
        }

        [HttpPost, Route("auth/login"), ActionName("Login")]
        public ActionResult LoginPost()
        {
            var viewModel = new LoginViewModel();
            if (!TryUpdateModel(viewModel) || !ModelState.IsValid)
            {
                return View(viewModel);
            }

            if (!_userService.IsExists(viewModel.Email))
            {
                ModelState.AddModelError("Email", "Użytkownik o podanym adresie e-mail nie istnieje");
                return View(viewModel);
            }

            var user = _userService.Users.FirstOrDefault(x => x.Email.Equals(viewModel.Email) && 
                                                         Decrypt.DecryptPassword(x.Password).Equals(viewModel.Password));
            
            if (user == null)
            {
                ModelState.AddModelError("", "Niepoprawny login lub hasło");
                return View(viewModel);
            }

            try
            {
                _authenticationService.SignIn(user);
                return RedirectToAction("Index", "Home");
            }            
            catch(Exception ex)
            {
                return View(viewModel);
            }                                             
        }
        //do innego pliku
        public ActionResult Signout()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("Index", "Home");
        }
    }
}