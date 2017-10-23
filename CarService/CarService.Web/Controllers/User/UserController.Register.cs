using CarService.Web.ViewModels.User;
using System;
using System.Web.Mvc;

namespace CarService.Web.Controllers.User
{
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
                if (_userService.IsExistsEmail(viewModel.Email))
                {
                    ModelState.AddModelError("Email", "Użytkownik o podanym adresie Email już istnieje");
                    return View(viewModel);
                }

                _userService.Create(viewModel.ToUser());
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View(viewModel);
        }
    }
}