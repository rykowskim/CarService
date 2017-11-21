using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarService.Web.ViewModels.Shared.Address
{
    public class AddressEdit
    {
        [DisplayName("Ulica")]
        [Required(ErrorMessage = "Pole Ulica jest wymagane")]
        public string Street { get; set; }

        [DisplayName("Numer mieszkania")]
        [Required(ErrorMessage = "Pole numer mieszkania jest wymagane")]
        public string FlatNumber { get; set; }

        [DisplayName("Kod pocztowy")]
        [Required(ErrorMessage = "Pole Kod pocztowy jest wymagane")]
        public string PostalCode { get; set; }

        [DisplayName("Miasto")]
        [Required(ErrorMessage = "Pole Miasto jest wymagane")]
        public string City { get; set; }

        private readonly Data.Models.Address _address;

        public AddressEdit(Data.Models.Address address)
        {
            _address = address ?? new Data.Models.Address();

            if (address != null)
            {
                Street = address.Street;
                FlatNumber = address.FlatNumber;
                PostalCode = address.PostalCode;
                City = address.City;
            }
        }

        public Data.Models.Address ToAddress()
        {
            _address.ModifyDate = DateTime.Now;
            _address.Street = Street;
            _address.FlatNumber = FlatNumber;
            _address.PostalCode = PostalCode;
            _address.City = City;

            return _address;
        }
        public Data.Models.Address ToNewAddress()
        {
            return new Data.Models.Address
            {
                IsActive = true,
                CreateDate = DateTime.Now,
                ModifyDate = DateTime.Now,
                Street = Street,
                FlatNumber = FlatNumber,
                PostalCode = PostalCode,
                City = City
            };
        }
    }
}