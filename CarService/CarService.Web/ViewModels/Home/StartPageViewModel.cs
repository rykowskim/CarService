using System.Collections.Generic;

namespace CarService.Web.ViewModels.Home
{
    public class StartPageViewModel
    {
        public string UserName { get; set; }
        public bool IsVerified { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; }
    }
}