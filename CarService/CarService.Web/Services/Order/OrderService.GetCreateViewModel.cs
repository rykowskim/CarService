using CarService.Web.Services.Other;
using CarService.Web.ViewModels.Order;
using System.Linq;
using System.Web.Mvc;

namespace CarService.Web.Services.Order
{
    public partial class OrderService
    {
        public Create GetCreateViewModel()
        {
            return new Create
            {
                Customers = _customerService.Customers.Select(n => new SelectListItem
                {
                    Value = n.Id.ToString(),
                    Text = n.Name
                }),
                OrderStatuses = OtherService.GetOrderStatuses(),
                OrderTypes = OtherService.GetOrderTypes(),
                Empolyees = _employeeService.Employees.Select(n => new SelectListItem
                {
                    Value = n.Id.ToString(),
                    Text = n.Name
                }),
                Cars = _carService.Cars.Select(n => new SelectListItem
                {
                    Value = n.Id.ToString(),
                    Text = string.Format("{0} {1}", n.Mark, n.Model)
                })
            };
        }
    }
}