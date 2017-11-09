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
    }
}