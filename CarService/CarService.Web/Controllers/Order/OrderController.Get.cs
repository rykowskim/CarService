using System.Web.Mvc;

namespace CarService.Web.Controllers.Order
{
    public partial class OrderController
    {
        [HttpGet, Route("Order/Get?{id}")]
        public ActionResult Get(int id)
        {
            return null;
        }
    }
}