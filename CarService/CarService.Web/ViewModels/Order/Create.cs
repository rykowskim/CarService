using CarService.Web.Services.Other;
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

        [DisplayName("Typ zlecenia"), Required(ErrorMessage = "Typ zlecenia jest wymagany")]
        public int OrderTypeId { get; set; }
        public IEnumerable<SelectListItem> OrderTypes { get; set; }

        [DisplayName("Przypisz do")]
        public int EmployeeId { get; set; }
        public IEnumerable<SelectListItem> Empolyees { get; set; }

        [DisplayName("Wybierz samochód"), Required(ErrorMessage = "Wybór samochodu jest wymagant")]
        public int CarId { get; set; }
        public IEnumerable<SelectListItem> Cars { get; set; }

        [DisplayName("Status zlecenia"), Required(ErrorMessage = "Musisz wybrać status zlecenia")]
        public int OrderStatusId { get; set; }
        public IEnumerable<SelectListItem> OrderStatuses { get; set; }

        [DisplayName("Uszkodzenia")]
        public string Symptoms { get; set; }

    }
}