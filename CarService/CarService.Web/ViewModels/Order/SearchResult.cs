namespace CarService.Web.ViewModels.Order
{
    public class SearchResult
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public string Car { get; set; }
        public string OrderType { get; set; }
        public string OrderStatus { get; set; }
        public string EmployeeName { get; set; }
    }
}