using PagedList;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;

namespace CarService.Web.ViewModels.Customer
{
    public class CustomerListFilters
    {
        [DisplayName("Nr klienta")]
        public int? CustomerId { get; set; }
        [DisplayName("Imię")]
        public string Name { get; set; }
        [DisplayName("Nazwisko")]
        public string Surname { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Sortowanie po")]
        public string SortedBy { get; set; }

        public IPagedList<ResultItem> ResultItems { get; set; }
        public IEnumerable<SelectListItem> SortedItems { get; set; }

        public CustomerListFilters()
        {
            SortedItems = new List<SelectListItem>
            {
                new SelectListItem { Value = "CustomerId ASC", Text = "Nr rosnąco" },
                new SelectListItem { Value = "CustomerId DESC", Text = "Nr malejąco" },
                new SelectListItem { Value = "Name ASC", Text = "Imię rosnąco" },
                new SelectListItem { Value = "NameDESC", Text = "Imię malejąco" },
                new SelectListItem { Value = "Surname ASC", Text = "Nazwisko rosnąco" },
                new SelectListItem { Value = "Surname DESC", Text = "Nazwisko malejąco" }
            };
        }
    }
}