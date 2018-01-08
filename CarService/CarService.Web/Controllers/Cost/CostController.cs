using CarService.Web.Services.Cost;
using CarService.Web.Services.Order;
using System.Web.Mvc;

namespace CarService.Web.Controllers.Cost
{
    public partial class CostController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ICostService _costService;

        public CostController(IOrderService orderService,
            ICostService costService)
        {
            _orderService = orderService;
            _costService = costService;
        }
    }
}