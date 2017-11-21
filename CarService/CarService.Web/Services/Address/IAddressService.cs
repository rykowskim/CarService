using System.Collections.Generic;

namespace CarService.Web.Services.Address
{
    public interface IAddressService
    {
        IEnumerable<Data.Models.Address> Addresses { get; }

        void Create(Data.Models.Address address);
    }
}