using CarService.Web.ViewModels.Employee;
using System;
using System.Linq;
using System.Web.Mvc;

namespace CarService.Web.Controllers.Employee
{
    public partial class EmployeeController
    {
        [HttpGet, Route("Employee/Edit")]
        public ActionResult Edit()
        {          
            var employee = _employeeService.Employees.Where(x => x.User_Id == GetUserId() && x.IsActive).First();

            var viewModel = new EmployeeEdit(employee)
            {
                Positions = _postionService.Positions.Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }),
                IsAdmin = User.IsInRole(Data.Enums.Role.Admin.ToString())
            };
            return View(viewModel);
        }

        [HttpPost, Route("Employee/Edit"), ActionName("Edit")]
        public ActionResult EditPost()
        {
            var employee = _employeeService.Employees.Where(x => x.User_Id == GetUserId() && x.IsActive).First();

            var viewModel = new EmployeeEdit(employee)
            {
                Positions = _postionService.Positions.Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }),
                IsAdmin = User.IsInRole(Data.Enums.Role.Admin.ToString())
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