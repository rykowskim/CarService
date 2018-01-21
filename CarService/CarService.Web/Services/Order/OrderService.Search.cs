using CarService.Web.ViewModels.Order;
using System.Collections.Generic;
using System.Linq;

namespace CarService.Web.Services.Order
{
    public partial class OrderService
    {
        public IEnumerable<SearchResult> Search(OrderListFilters filters)
        {

            var records = Orders.Where(x => (filters.OrderId == null || x.Id == filters.OrderId) &&
                                            (string.IsNullOrEmpty(filters.Customer) || string.Format("{0} {1}", x.Customer.Name, x.Customer.Surname).Contains(filters.Customer)) &&
                                            (string.IsNullOrEmpty(filters.Car) || string.Format("{0} {1}", x.Car.Mark, x.Car.Model).Contains(filters.Car)) &&
                                            (filters.OrderTypeId == null || x.OrderType.Id == filters.OrderTypeId) &&
                                            (filters.OrderStatusId == null || x.OrderStatus.Id == filters.OrderStatusId) &&
                                            (filters.EmployeeId == null || x.Employee.Id == filters.EmployeeId));


            var result = records.Select(n => new SearchResult
            {
                OrderId = n.Id,
                CustomerName = string.Format("{0} {1}", n.Customer.Name, n.Customer.Surname),
                Car = string.Format("{0} {1}", n.Car.Mark, n.Car.Model),
                OrderStatus = n.OrderStatus.Name,
                OrderType = n.OrderType.Name,
                EmployeeName = string.Format("{0} {1}", n.Employee.Name, n.Employee.Surname)
            });

            switch (filters.SortedBy)
            {
                case "OrderId ASC":
                    return result.OrderBy(x => x.OrderId);
                    break;
                case "OrderId DESC":
                    return result.OrderByDescending(x => x.OrderId);
                    break;
                case "Customer ASC":
                    return result.OrderBy(x => x.CustomerName);
                    break;
                case "Customer DESC":
                    return result.OrderByDescending(x => x.CustomerName);
                    break;
                case "Car ASC":
                    return result.OrderBy(x => x.Car);
                    break;
                case "Car DESC":
                    return result.OrderByDescending(x => x.Car);
                    break;
                default:
                    return result.OrderBy(x => x.OrderId);
                    break;
            }
            
        }
    }
}