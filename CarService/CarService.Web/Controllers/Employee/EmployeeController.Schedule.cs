using System.Web.Mvc;

namespace CarService.Web.Controllers.Employee
{
    public partial class EmployeeController
    {
        [Route("Employee/Schedule")]
        public ActionResult Schedule(int id)
        {
            var viewModel = _employeeService.GetSchedule(id);
            return View(viewModel);
        }
    }
}