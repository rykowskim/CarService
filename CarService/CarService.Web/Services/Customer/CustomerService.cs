using CarService.Data.Models;
using CarService.Web.ViewModels.Customer;
using System.Collections.Generic;
using System.Linq;

namespace CarService.Web.Services.Customer
{
    public class CustomerService : ICustomerService
    {
        private CarServiceContext dbContext = new CarServiceContext();

        public IEnumerable<Data.Models.Customer> Customers => dbContext.Customer;

        public void Create(Data.Models.Customer customer)
        {
            dbContext.Customer.Add(customer);
            dbContext.SaveChanges();
        }

        public IEnumerable<ResultItem> Search(CustomerListFilters filter)
        {
            var records = Customers.Where(x => (filter.CustomerId == null || x.Id == filter.CustomerId) &&
                                            (string.IsNullOrEmpty(filter.Name) || x.Name.Contains(filter.Name)) &&
                                            (string.IsNullOrEmpty(filter.Surname) || x.Surname.Contains(filter.Surname)) &&
                                            (string.IsNullOrEmpty(filter.Email) || x.Email.Contains(filter.Email)));

            var result = records.Select(n => new ResultItem
            {
                CustomerId = n.Id,
                Name = n.Name,
                Surname = n.Surname,
                Email = n.Email,
                Phone = n.Phone,
                Address = string.Format("{0} m.{1}, {2} {3}", n.Address.Street, n.Address.FlatNumber, n.Address.PostalCode, n.Address.City)
            });

            switch (filter.SortedBy)
            {
                case "CustomerId ASC":
                    return result.OrderBy(x => x.CustomerId);
                    break;
                case "CustomerId DESC":
                    return result.OrderByDescending(x => x.CustomerId);
                    break;
                case "Name ASC":
                    return result.OrderBy(x => x.Name);
                    break;
                case "Name DESC":
                    return result.OrderByDescending(x => x.Name);
                    break;
                case "Surname ASC":
                    return result.OrderBy(x => x.Surname);
                    break;
                case "Surname DESC":
                    return result.OrderByDescending(x => x.Surname);
                    break;
                default:
                    return result.OrderBy(x => x.CustomerId);
                    break;
            }
        }
    }
}