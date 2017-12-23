using CarService.Web.Services.Other;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;

namespace CarService.Web.ViewModels.Order
{
    public class EditOrder
    {
        public int Id { get; set; }
        [DisplayName("Klient")]
        public string Customer { get; set; }
        [DisplayName("Typ zlecenia")]
        public string OrderType { get; set; }
        [DisplayName("Przypisany do")]
        public string Employee { get; set; }
        [DisplayName("Samochód")]
        public string Car { get; set; }
        [DisplayName("Status zlecenia")]
        public string OrderStatus { get; set; }
        [DisplayName("Uszkodzenia")]
        public string RepairDescription { get; set; }

        public int EmployeeId { get; set; }
        public int OrderStatusId { get; set; }

        public IEnumerable<SelectListItem> OrderStatuses { get; set; }
        public IEnumerable<SelectListItem> Employees { get; set; }

        public string ReturnUrl { get; set; }

        private readonly Data.Models.Order _order;

        public EditOrder(Data.Models.Order order)
        {
            _order = order;
            Id = order.Id;
            Car = string.Format("{0} {1}", order.Car.Mark, order.Car.Model);
            Customer = string.Format("{0} {1}", order.Customer.Name, order.Customer.Surname);
            Employee = string.Format("{0} {1}", order.Employee.Name, order.Employee.Surname);
            OrderStatus = order.OrderStatus.Name;
            OrderType = order.OrderType.Name;
            RepairDescription = order.RepairDescription;
            EmployeeId = order.Employee.Id;
            OrderStatusId = order.OrderStatus.Id;
            OrderStatuses = OtherService.GetOrderStatuses();
        }

        public Data.Models.Order ToEdit()
        {
            _order.OrderStatus_Id = OrderStatusId;
            _order.Employee_Id = EmployeeId;
            _order.RepairDescription = RepairDescription;

            return _order;
        }
    }
}