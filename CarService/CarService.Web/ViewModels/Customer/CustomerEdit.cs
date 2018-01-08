using CarService.Web.ViewModels.Shared.Address;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarService.Web.ViewModels.Customer
{
    public class CustomerEdit
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Imię jest wymagane")]
        [DisplayName("Imię")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        [DisplayName("Nazwisko")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Telefon jest wymagane")]
        [DisplayName("Telefon")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Adres e-mail jest wymagany")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        public AddressEdit AddressEdit { get; set; }

        public string ReturnUrl { get; set; }

        private readonly Data.Models.Customer _customer;

        public CustomerEdit(Data.Models.Customer customer)
        {
            _customer = customer ?? new Data.Models.Customer();

            if (customer != null && customer.Id != 0)
                Id = customer.Id;

            Name = customer.Name;
            Surname = customer.Surname;
            Phone = customer.Phone;
            Email = customer.Email;
            AddressEdit = new AddressEdit(customer.Address);
        }

        public Data.Models.Customer ToCustomer()
        {
            if (_customer.Id == 0)
            {
                _customer.CreateDate = DateTime.Now;
                _customer.IsActive = true;
            }

            _customer.ModifyDate = DateTime.Now;
            _customer.Name = Name;
            _customer.Surname = Surname;
            _customer.Phone = Phone;
            _customer.Email = Email;
            _customer.Address = _customer.Address == null ? AddressEdit.ToNewAddress() : AddressEdit.ToAddress();

            return _customer;
        }


    }
}