using CarService.Web.ViewModels.Car;
using System.Collections.Generic;

namespace CarService.Web.ViewModels.Customer
{
    public class Edit
    {
        public CustomerEdit Customer { get; set; }
        public IEnumerable<CarItem> Cars { get; set; }
    }
}