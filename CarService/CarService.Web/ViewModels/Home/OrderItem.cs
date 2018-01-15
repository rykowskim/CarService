namespace CarService.Web.ViewModels.Home
{
    public class OrderItem
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string Customer { get; set; }
        public string Car { get; set; }
        public string OrderType { get; set; }
        public string OrderStatus { get; set; }
        public int EmployeeId { get; set; }
        public string Employee { get; set; }
    }
}