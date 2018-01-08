using CarService.Web.ViewModels.Customer;
using PagedList;
using System;
using System.Web.Mvc;

namespace CarService.Web.Controllers.Customer
{
    public partial class CustomerController
    {
        [HttpGet, Route("Customer/List")]
        public ActionResult List(int? page)
        {
            var viewModel = new CustomerListFilters();
            var pageIndex = page ?? 1;
            viewModel.ResultItems = _customerService.Search(viewModel).ToPagedList(pageIndex, 5);
            return View(viewModel);
        }

        [HttpPost, Route("Customer/List"), ActionName("List")]
        public ActionResult ListPost(int? page)
        {
            var viewModel = new CustomerListFilters();

            if (!TryUpdateModel(viewModel) || !ModelState.IsValid)
            {
                return View(viewModel);
            }

            try
            {
                var pageIndex = page ?? 1;
                viewModel.ResultItems = _customerService.Search(viewModel).ToPagedList(pageIndex, 5);
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