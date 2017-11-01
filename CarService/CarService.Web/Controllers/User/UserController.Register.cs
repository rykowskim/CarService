using CarService.Web.Mvc.Other;
using CarService.Web.ViewModels.User;
using System;
using System.Web.Mvc;

namespace CarService.Web.Controllers.User
{
    [AllowAnonymous]
    public partial class UserController
    {
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
                return View(viewModel);
            }

            try
            {
                if (_userService.IsExists(viewModel.Email))
                {
                    ModelState.AddModelError("Email", "Użytkownik o podanym adresie e-mail już istnieje");
                    return View(viewModel);
                }

                _userService.Create(viewModel.ToUser());
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return RedirectToAction("Index", "Home");
        }
    }
}