using System.Web.Mvc;

namespace CarService.Web.Controllers.Employee
{
    public partial class EmployeeController
    {
        [HttpGet, Route("Employee/ProfileEdit")]
        public ActionResult ProfileEdit()
        {
            return View();
        }
    }
}