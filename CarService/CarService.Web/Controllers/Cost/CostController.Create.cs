using CarService.Web.ViewModels.Cost;
using System;
using System.Linq;
using System.Web.Mvc;

namespace CarService.Web.Controllers.Cost
{
    public partial class CostController
    {
        [HttpGet, Route("Cost/Create")]
        public ActionResult Create(int id, string returnUrl)
        {
            var order = _orderService.Orders.Where(x => x.Id == id && x.IsActive).FirstOrDefault();
            var viewModel = new EditCost(new Data.Models.Cost())
            {
                Order = new ViewModels.Order.EditOrder(order)
            };
            viewModel.ReturnUrl = returnUrl;
            return View(viewModel);
        }

        [HttpPost, Route("Cost/Create"), ActionName("Create")]
        public ActionResult CreatePost(int id, string returnUrl)
        {
            var order = _orderService.Orders.Where(x => x.Id == id && x.IsActive).FirstOrDefault();
            var viewModel = new EditCost(new Data.Models.Cost())
            {
                Order = new ViewModels.Order.EditOrder(order)
            };

            if (!TryUpdateModel(viewModel) || !ModelState.IsValid)
            {
                return View(viewModel);
            }

            try
            {
                _costService.Create(viewModel.ToModel());
                return RedirectToAction("Edit", "Order", new { id = order.Id });
            }
            catch (Exception ex)
            {
                return View(viewModel);
                throw ex;
            }
        }
    }
}