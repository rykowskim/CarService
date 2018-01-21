using CarService.Web.ViewModels.Employee;
using PagedList;
using System;
using System.Linq;
using System.Web.Mvc;

namespace CarService.Web.Controllers.Employee
{
    public partial class EmployeeController
    {
        [HttpGet, Route("Employee/Search")]
        public ActionResult Search(int? page)
        {
            var viewModel = new EmployeeSearchItem
            {
                Positions = _postionService.Positions.Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }),
                AuthenticatedUserId = GetUserId()
            };
            var pageIndex = page ?? 1;
            viewModel.ResultItems = _employeeService.Search(viewModel).ToPagedList(pageIndex, 5);
            return View(viewModel);
        }

        [HttpPost, Route("Employee/Search"), ActionName("Search")]
        public ActionResult SearchPost(int? page)
        {
            var viewModel = new EmployeeSearchItem
            {
                Positions = _postionService.Positions.Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }),
                AuthenticatedUserId = GetUserId()
            };

            if (!TryUpdateModel(viewModel) || !ModelState.IsValid)
            {
                return View(viewModel);
            }

            try
            {
                var pageIndex = page ?? 1;
                viewModel.ResultItems = _employeeService.Search(viewModel).ToPagedList(pageIndex, 5);
                return View(viewModel);
            }
            catch (Exception ex)
            {
                return View(viewModel);
                throw ex;
            }
        }
    }
}