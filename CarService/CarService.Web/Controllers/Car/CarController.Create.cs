using CarService.Web.ViewModels.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CarService.Web.Controllers.Car
{
    public partial class CarController
    {
        [HttpGet, Route("Car/Create/{id?}")]
        public ActionResult Create([Bind(Prefix = "id")]int? customerId)
        {
            var viewModel = new CarCreate
            {
                Customers = _customerService.Customers.Select(n => new SelectListItem
                {
                    Value = n.Id.ToString(),
                    Text = string.Format("{0} {1}", n.Name, n.Surname)
                })
            };

            if (customerId.HasValue)
                viewModel.CustomerId = customerId.Value;

            return View(viewModel);
        }

        [HttpPost, Route("Car/Create/{id?}"), ActionName("Create")]
        public ActionResult CreatePost([Bind(Prefix = "id")]int? customerId)
        {
            var viewModel = new CarCreate
            {
                Customers = _customerService.Customers.Select(n => new SelectListItem
                {
                    Value = n.Id.ToString(),
                    Text = string.Format("{0} {1}", n.Name, n.Surname)
                })
            };

            if (customerId.HasValue)
                viewModel.CustomerId = customerId.Value;

            if (!TryUpdateModel(viewModel) || !ModelState.IsValid)
            {
                return View(viewModel);
            }

            try
            {
                var model = viewModel.ToCar();
                _carService.Create(model);
                //Session["CarCreateSessionKey"] = new List<int>() { customerId.Value, model.Id };
                if (customerId.HasValue)
                {
                    Session["CarCreateSessionKey"] = new List<KeyValuePair<string, int>>()
                    {
                         new KeyValuePair<string, int>("Customer", customerId.Value),
                         new KeyValuePair<string, int>("Car", model.Id)
                    };
                }
            }
            catch (Exception ex)
            {
                return View(viewModel);
                throw ex;
            }

            return RedirectToAction("Create", "Order");


        }
    }
}