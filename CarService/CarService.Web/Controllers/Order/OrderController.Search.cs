using CarService.Web.ViewModels.Order;
using PagedList;
using System;
using System.Linq;
using System.Web.Mvc;

namespace CarService.Web.Controllers.Order
{
    public partial class OrderController
    {
        [HttpGet, Route("Order/Search")]
        public ActionResult Search(int? page)
        {
            var viewModel = new OrderListFilters
            {
                Employees = _employeeService.Employees.Where(x => x.IsActive && x.IsVerified)
                                                      .Select(n => new SelectListItem
                                                      {
                                                          Value = n.Id.ToString(),
                                                          Text = string.Format("{0} {1}", n.Name, n.Surname)
                                                      }) 
            };
            var pageIndex = page ?? 1;
            viewModel.Results = _orderService.Search(viewModel).ToPagedList(pageIndex, 10);
            return View(viewModel);
        }

        [HttpPost, Route("Order/Search"), ActionName("Search")]
        public ActionResult SearchPost(int? page)
        {
            var viewModel = new OrderListFilters
            {
                Employees = _employeeService.Employees.Where(x => x.IsActive && x.IsVerified)
                                                      .Select(n => new SelectListItem
                                                      {
                                                          Value = n.Id.ToString(),
                                                          Text = string.Format("{0} {1}", n.Name, n.Surname)
                                                      })
            };

            if (!TryUpdateModel(viewModel) || !ModelState.IsValid)
            {
                return View(viewModel);
            }

            try
            {
                var pageIndex = page ?? 1;
                viewModel.Results = _orderService.Search(viewModel).ToPagedList(pageIndex, 10);
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