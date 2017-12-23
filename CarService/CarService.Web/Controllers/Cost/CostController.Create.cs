using CarService.Web.ViewModels.Cost;
using System.Linq;
using System.Web.Mvc;

namespace CarService.Web.Controllers.Cost
{
    public partial class CostController
    {
        [HttpGet, Route("Cost/Create")]
        public ActionResult Create(int id)
        {
            var order = _orderService.Orders.Where(x => x.Id == id && x.IsActive).FirstOrDefault();
            var viewModel = new EditCost(new Data.Models.Cost())
            {
                Order = new ViewModels.Order.EditOrder(order)
            };
            return View(viewModel);
        }

        [HttpPost, Route("Cost/Create"), ActionName("Create")]
        public ActionResult CreatePost(int id)
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

            return null;
        }
    }
}