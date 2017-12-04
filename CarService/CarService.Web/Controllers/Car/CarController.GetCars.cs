using System.Linq;
using System.Web.Mvc;

namespace CarService.Web.Controllers.Car
{
    public partial class CarController
    {
        [HttpGet, Route("Car/GetCars/{id?}")]
        public JsonResult GetCars(int? id)
        {
            var records = _carService.Cars.Where(x => x.IsActive && x.Customer.Id == id);
            var result = records.Select(n => new SelectListItem
            {
                Value = n.Id.ToString(),
                Text = string.Format("{0} {1}", n.Mark, n.Model)
            });

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}