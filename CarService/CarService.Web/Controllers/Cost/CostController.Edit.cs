using CarService.Web.ViewModels.Cost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarService.Web.Controllers.Cost
{
    public partial class CostController
    {
        [HttpGet, Route("Cost/Edit")]
        public ActionResult Edit(int id, string returnUrl)
        {
            var cost = _costService.Costs.FirstOrDefault(x => x.Id == id && x.IsActive);
            var viewModel = new EditCost(cost)
            {
                Order = new ViewModels.Order.EditOrder(cost.Order)
            };
            viewModel.ReturnUrl = returnUrl;
            return View(viewModel);
        }

        [HttpPost, Route("Cost/Edit"), ActionName("Edit")]
        public ActionResult EditPost(int id, string returnUrl)
        {
            var cost = _costService.Costs.FirstOrDefault(x => x.Id == id && x.IsActive);
            var viewModel = new EditCost(cost)
            {
                Order = new ViewModels.Order.EditOrder(cost.Order)
            };

            if (!TryUpdateModel(viewModel) || !ModelState.IsValid)
            {
                return View(viewModel);
            }

            try
            {
                _costService.Update(viewModel.ToModel());
                return RedirectToAction("Edit", "Order", new { id = cost.Order.Id });
            }
            catch (Exception ex)
            {
                return View(viewModel);
                throw ex;
            }
        }
    }
}