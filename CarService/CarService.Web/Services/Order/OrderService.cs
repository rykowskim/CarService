using CarService.Data.Models;
using CarService.Web.Services.Car;
using CarService.Web.Services.Customer;
using CarService.Web.Services.Employee;
using System.Collections.Generic;

namespace CarService.Web.Services.Order
{
    public partial class OrderService : IOrderService
    {
        private CarServiceContext dbContext = new CarServiceContext();

        private readonly ICustomerService _customerService;
        private readonly IEmployeeService _employeeService;
        private readonly ICarsService _carService;

        public OrderService(ICustomerService customerService,
            IEmployeeService employeeService,
            ICarsService carService)
        {
            _customerService = customerService;
            _employeeService = employeeService;
            _carService = carService;
        }

        public IEnumerable<Data.Models.Order> Orders => dbContext.Order;

        public void Create(Data.Models.Order order)
        {
            dbContext.Entry(order.Car).State = System.Data.Entity.EntityState.Unchanged;
            dbContext.Entry(order.Customer).State = System.Data.Entity.EntityState.Unchanged;
            dbContext.Entry(order.OrderStatus).State = System.Data.Entity.EntityState.Unchanged;
            dbContext.Entry(order.OrderType).State = System.Data.Entity.EntityState.Unchanged;
            dbContext.Entry(order.Employee).State = System.Data.Entity.EntityState.Unchanged;
            dbContext.Order.Add(order);
            dbContext.SaveChanges();
        }

        public void Update(Data.Models.Order order)
        {
            dbContext.Entry(order.OrderStatus).State = System.Data.Entity.EntityState.Unchanged;
            dbContext.Entry(order.Employee).State = System.Data.Entity.EntityState.Unchanged;
            dbContext.Entry(order).State = System.Data.Entity.EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}