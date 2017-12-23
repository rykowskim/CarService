using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CarService.Web.ViewModels.Order
{
    public class Create
    {
        [DisplayName("Wybierz klienta"), Required(ErrorMessage = "Wybór klienta jest wymagany")]
        public int CustomerId { get; set; }
        public IEnumerable<SelectListItem> Customers { get; set; }

        [DisplayName("Typ"), Required(ErrorMessage = "Typ zlecenia jest wymagany")]
        public int OrderTypeId { get; set; }
        public IEnumerable<SelectListItem> OrderTypes { get; set; }

        [DisplayName("Przypisz do pracownika")]
        public int EmployeeId { get; set; }
        public IEnumerable<SelectListItem> Empolyees { get; set; }

        [DisplayName("Wybierz samochód"), Required(ErrorMessage = "Wybór samochodu jest wymagant")]
        public int CarId { get; set; }
        public IEnumerable<SelectListItem> Cars { get; set; }

        [DisplayName("Status zlecenia"), Required(ErrorMessage = "Musisz wybrać status zlecenia")]
        public int OrderStatusId { get; set; }
        public IEnumerable<SelectListItem> OrderStatuses { get; set; }

        [DisplayName("Uszkodzenia")]
        public string RepairDescription { get; set; }

        public string ReturnUrl { get; set; }

        private readonly Data.Models.Order _order;

        public Create(Data.Models.Order order)
        {
            _order = order;
        }


        public Data.Models.Order ToOrder()
        {
            _order.CreateDate = DateTime.Now;
            _order.ModifyDate = DateTime.Now;
            _order.IsActive = true;
            _order.Customer = new Data.Models.Customer { Id = CustomerId };
            _order.OrderType = new Data.Models.OrderType { Id = OrderTypeId };
            _order.Employee = new Data.Models.Employee { Id = EmployeeId };
            _order.Car = new Data.Models.Car { Id = CarId };
            _order.OrderStatus = new Data.Models.OrderStatus { Id = OrderStatusId };
            _order.RepairDescription = RepairDescription;

            return _order;
        }

    }

}