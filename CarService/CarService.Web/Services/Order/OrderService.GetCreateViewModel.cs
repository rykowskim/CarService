using CarService.Web.Services.Other;
using CarService.Web.ViewModels.Order;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CarService.Web.Services.Order
{
    public partial class OrderService
    {
        public Create GetCreateViewModel(Data.Models.Order order)
        {
            return new Create(order)
            {
                Customers = _customerService.Customers.Select(n => new SelectListItem
                {
                    Value = n.Id.ToString(),
                    Text = string.Format("{0} {1}", n.Name, n.Surname)
                }),
                OrderStatuses = OtherService.GetOrderStatuses(),
                OrderTypes = OtherService.GetOrderTypes(),
                Empolyees = _employeeService.Employees.Select(n => new SelectListItem
                {
                    Value = n.Id.ToString(),
                    Text = string.Format("{0} {1}", n.Name, n.Surname)
                }),
                Cars = new List<SelectListItem>()
            };
        }
    }
}