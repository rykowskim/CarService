using PagedList;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;

namespace CarService.Web.ViewModels.Employee
{
    public class EmployeeSearchItem
    {
        [DisplayName("Imię")]
        public string Name { get; set; }

        [DisplayName("Nazwisko")]
        public string Surname { get; set; }

        [DisplayName("E-mail")]
        public string Email { get; set; }

        [DisplayName("Stanowisko")]
        public int? PositionId { get; set; }
        public IEnumerable<SelectListItem> Positions { get; set; }

        public IPagedList<ResultItem> ResultItems { get; set; }
    }
}