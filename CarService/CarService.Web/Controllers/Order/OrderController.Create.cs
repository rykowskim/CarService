using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarService.Web.Controllers.Order
{
    public partial class OrderController
    {
        [HttpGet, Route("Order/Create")]
        public ActionResult Create(string returnUrl)
        {
            var session = Session["CarCreateSessionKey"] as List<KeyValuePair<string, int>>;
            var viewModel = _orderService.GetCreateViewModel(new Data.Models.Order());
            if (session != null)
            {
                viewModel.CustomerId = session.First(x => x.Key.Equals("Customer")).Value;
                viewModel.Cars = _carService.Cars.Where(x => x.Customer.Id == viewModel.CustomerId)
                                                 .Select(n => new SelectListItem
                                                 {
                                                     Value = n.Id.ToString(),
                                                     Text = string.Format("{0} {1}", n.Mark, n.Model)
                                                 });
                viewModel.CarId = session.First(x => x.Key.Equals("Car")).Value;
                Session["CarCreateSessionKey"] = null;
            }
            viewModel.ReturnUrl = returnUrl;
            return View(viewModel);
        }

        [HttpPost, Route("Order/Create"), ActionName("Create")]
        public ActionResult CreatePost()
        {
            var session = Session["CarCreateSessionKey"] as List<KeyValuePair<string, int>>;
            var viewModel = _orderService.GetCreateViewModel(new Data.Models.Order());
            if (session != null)
            {
                viewModel.CustomerId = session.First(x => x.Key.Equals("Customer")).Value;
                viewModel.Cars = _carService.Cars.Where(x => x.Customer.Id == viewModel.CustomerId)
                                                 .Select(n => new SelectListItem
                                                 {
                                                     Value = n.Id.ToString(),
                                                     Text = string.Format("{0} {1}", n.Mark, n.Model)
                                                 });
                viewModel.CarId = session.First(x => x.Key.Equals("Car")).Value;
                Session["CarCreateSessionKey"] = null;
            }

            if (!TryUpdateModel(viewModel))
            {
                return View(viewModel);
            }

            try
            {
                var toModel = viewModel.ToOrder();
                _orderService.Create(toModel);
                return RedirectToAction("Edit", "Order", new { id = toModel.Id });
            }
            catch(Exception ex)
            {
                return View(viewModel);
                throw ex;
            }
            
        }
    }
}