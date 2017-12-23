using CarService.Web.Services.Other;
using PagedList;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;

namespace CarService.Web.ViewModels.Order
{
    public class OrderListFilters
    {
        [DisplayName("Nr zlecenia")]
        public int? OrderId { get; set; }
        [DisplayName("Klient")]
        public string Customer { get; set; }
        [DisplayName("Samochód")]
        public string Car { get; set; }
        [DisplayName("Typ zlecenia")]
        public int? OrderTypeId { get; set; }
        [DisplayName("Status zlecenia")]
        public int? OrderStatusId { get; set; }
        [DisplayName("Sortowanie po")]
        public string SortedBy { get; set; }
        public IEnumerable<SelectListItem> OrderTypes { get; set; }
        public IEnumerable<SelectListItem> OrderStatuses { get; set; }
        public IEnumerable<SelectListItem> SortedItems { get; set; }

        public IPagedList<SearchResult> Results { get; set; }

        public OrderListFilters()
        {
            OrderTypes = OtherService.GetOrderTypes();
            OrderStatuses = OtherService.GetOrderStatuses();
            SortedItems = new List<SelectListItem>
            {
                new SelectListItem { Value = "OrderId ASC", Text = "Id rosnąco" },
                new SelectListItem { Value = "OrderId DESC", Text = "Id malejąco" },
                new SelectListItem { Value = "Customer ASC", Text = "Klien rosnąco" },
                new SelectListItem { Value = "Customer DESC", Text = "Klient malejąco" },
                new SelectListItem { Value = "Car ASC", Text = "Samochód rosnąco" },
                new SelectListItem { Value = "Car DESC", Text = "Samochód malejąco" }
            };
        }
    }
}