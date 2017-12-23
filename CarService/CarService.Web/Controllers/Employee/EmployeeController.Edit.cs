using CarService.Web.ViewModels.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;

namespace CarService.Web.Controllers.Employee
{
    public partial class EmployeeController
    {
        [HttpGet, Route("Employee/Edit")]
        public ActionResult Edit()
        {
            var identity = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            var id = int.Parse(claims.Where(x => x.Type == "Id").Select(w => w.Value).FirstOrDefault());

            var employee = _employeeService.Employees.Where(x => x.User_Id == id && x.IsActive).First();

            var viewModel = new EmployeeEdit(employee)
            {
                Positions = _postionService.Positions.Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                })
            };
            return View(viewModel);
        }

        [HttpPost, Route("Employee/Edit"), ActionName("Edit")]
        public ActionResult EditPost()
        {
            var identity = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            var id = int.Parse(claims.Where(x => x.Type == "Id").Select(w => w.Value).FirstOrDefault());

            var employee = _employeeService.Employees.Where(x => x.User_Id == id && x.IsActive).First();

            var viewModel = new EmployeeEdit(employee)
            {
                Positions = _postionService.Positions.Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                })
            };

            if (!TryUpdateModel(viewModel) || !ModelState.IsValid)
            {
                return View(viewModel);
            }
            
            try
            {             
                var toModel = viewModel.ToEmployee();
                _employeeService.Update(toModel);
            }
            catch (Exception ex)
            {
                return View(viewModel);
                throw ex;
            }

            return RedirectToAction("Index", "Home");
        }
    }
}