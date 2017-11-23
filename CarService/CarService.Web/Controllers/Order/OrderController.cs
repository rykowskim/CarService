using CarService.Web.Services.Order;
using System.Web.Mvc;

namespace CarService.Web.Controllers.Order
{
    public partial class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
    }
}