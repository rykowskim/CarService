using System.Web.Mvc;

namespace CarService.Web.Controllers.Order
{
    public partial class OrderController
    {
        [HttpGet, Route("Order/Create")]
        public ActionResult Create()
        {
            var viewModel = _orderService.GetCreateViewModel();
            return View(viewModel);
        }
    }
}