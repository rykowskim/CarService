using CarService.Web.ViewModels.Employee;
using System;
using System.Linq;
using System.Web.Mvc;

namespace CarService.Web.Controllers.Employee
{
    public partial class EmployeeController
    {
        [HttpGet, Route("Employee/Create")]
        public ActionResult Create(string returnUrl)
        {
            var viewModel = new Create
            {
                AddressEdit = new ViewModels.Shared.Address.AddressEdit(new Data.Models.Address()),
                Positions = _postionService.Positions.Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }),
                ReturnUrl = returnUrl
            };

            return View(viewModel);
        }

        [HttpPost, Route("Employee/Create"), ActionName("Create")]
        public ActionResult CreatePost(string returnUrl)
        {

            var viewModel = new Create
            {
                AddressEdit = new ViewModels.Shared.Address.AddressEdit(new Data.Models.Address()),
                Positions = _postionService.Positions.Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }),
                ReturnUrl = returnUrl
            };

            if (!TryUpdateModel(viewModel) || !ModelState.IsValid)
            {
                return View(viewModel);
            }

            if (_userService.IsExists(viewModel.Email))
            {
                ModelState.AddModelError("Email", "Użytkownik o podanym adresie e-mail już istnieje");
                return View(viewModel);
            }

            try
            {
                var user = viewModel.ToUser();
                _userService.Create(user);
                _employeeService.Create(viewModel.ToEmployee(user));

                return Redirect(viewModel.ReturnUrl);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "Błąd podczas tworzenia pracownika");
                return View(viewModel);
                throw ex;
            }
        }
    }
}