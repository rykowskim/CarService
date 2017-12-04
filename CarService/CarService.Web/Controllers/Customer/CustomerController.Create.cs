using CarService.Web.ViewModels.Customer;
using System;
using System.Web.Mvc;

namespace CarService.Web.Controllers.Customer
{
    public partial class CustomerController
    {
        [HttpGet, Route("Customer/Create")]
        public ActionResult Create()
        {
            var viewModel = new CustomerEdit(new Data.Models.Customer());
            return View(viewModel);
        }

        [HttpPost, Route("Customer/Create"), ActionName("Create")]
        public ActionResult CreatePost()
        {
            var viewModel = new CustomerEdit(new Data.Models.Customer());

            if (!TryUpdateModel(viewModel) || !ModelState.IsValid)
            {
                return View(viewModel);
            }

            try
            {
                var model = viewModel.ToCustomer();
                _customerService.Create(model);
            }
            catch(Exception ex)
            {
                return View(viewModel);
            }

            return RedirectToAction("Create", "Order");
        }
    }
}