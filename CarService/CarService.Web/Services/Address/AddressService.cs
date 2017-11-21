using CarService.Data.Models;
using System.Collections.Generic;

namespace CarService.Web.Services.Address
{
    public class AddressService : IAddressService
    {
        private CarServiceContext dbContext = new CarServiceContext();

        public IEnumerable<Data.Models.Address> Addresses => dbContext.Address;

        public void Create(Data.Models.Address address)
        {
            dbContext.Address.Add(address);
            dbContext.SaveChanges();
        }
    }
}