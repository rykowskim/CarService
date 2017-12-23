using CarService.Web.Services.Order;
using System.Web.Mvc;

namespace CarService.Web.Controllers.Cost
{
    public partial class CostController : Controller
    {
        private readonly IOrderService _orderService;

        public CostController(IOrderService orderService)
        {
            _orderService = orderService;
        }
    }
}