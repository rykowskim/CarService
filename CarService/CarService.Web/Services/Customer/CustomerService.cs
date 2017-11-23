using CarService.Data.Models;
using System.Collections.Generic;

namespace CarService.Web.Services.Customer
{
    public class CustomerService : ICustomerService
    {
        private CarServiceContext dbContext = new CarServiceContext();

        public IEnumerable<Data.Models.Customer> Customers => dbContext.Customer;
    }
}