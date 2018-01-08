using System;

namespace CarService.Web.ViewModels.Employee
{
    public class Schedule
    {
        public int OrderId { get; set; }
        public string CreateDate { get; set; }
        public string CustomerName { get; set; }
        public string Car { get; set; }
        public string OrderStatus { get; set; }
    }
}