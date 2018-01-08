using CarService.Web.ViewModels.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarService.Web.Controllers.Customer
{
    public partial class CustomerController
    {
        [HttpGet, Route("Customer/Edit")]
        public ActionResult Edit(int id, string returnUrl)
        {
            var customer = _customerService.Customers.FirstOrDefault(x => x.Id == id && x.IsActive);
            if (customer == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var viewModel = new CustomerEdit(customer)
            {
                ReturnUrl = returnUrl
            };
            return View(viewModel);
        }

        [HttpPost, Route("Customer/Edit"), ActionName("Edit")]
        public ActionResult EditPost(int id,string returnUrl)
        {
            var customer = _customerService.Customers.FirstOrDefault(x => x.Id == id && x.IsActive);
            if (customer == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var viewModel = new CustomerEdit(customer);

            if (!TryUpdateModel(viewModel) || !ModelState.IsValid)
            {
                return View(viewModel);
            }

            try
            {
                var model = viewModel.ToCustomer();
                _customerService.Create(model);
            }
            catch (Exception ex)
            {
                return View(viewModel);
                throw ex;
            }

            //return RedirectToAction("Create", "Order");
            return Redirect(returnUrl);
        }
    }
}