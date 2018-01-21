using CarService.Web.Mvc.Other;
using CarService.Web.ViewModels.Shared.Address;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarService.Web.ViewModels.Employee
{
    public class Create : IValidatableObject
    {
        [DisplayName("Imię"), Required(ErrorMessage = "Imię jest wymagane")]
        public string Name { get; set; }

        [DisplayName("Nazwisko"), Required(ErrorMessage = "Nazwisko jest wymagane")]
        public string Surname { get; set; }

        [DisplayName("PESEL"), Required(ErrorMessage = "Pesel jest wymagany")]
        public string Pesel { get; set; }

        [Phone]
        [DisplayName("Telefon")]
        public string Phone { get; set; }

        [DisplayName("Email"), Required(ErrorMessage = "Email jest wymagany")]
        [EmailAddress]
        public string Email { get; set; }

        [DisplayName("Data urodzenia"), Required(ErrorMessage = "Data urodzenia jest wymagana")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [DisplayName("Pensja")]
        public decimal? Salary { get; set; }

        [DisplayName("Stanowisko")]
        public int PositionId { get; set; }
        public IEnumerable<SelectListItem> Positions { get; set; }

        public bool IsAdministrator { get; set; }

        public AddressEdit AddressEdit { get; set; }

        public string ReturnUrl { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsValidBirthDay())
            {
                yield return new ValidationResult("Musisz mieć ukończone 18 lat", new[] { "BirthDate" });
            }
        }

        private bool IsValidBirthDay()
        {
            const long AgeOfAdult = 567648000000;

            var dt1900 = new DateTime(1900, 1, 1);
            var current = DateTime.Now;
            var spanCurrent = current - dt1900;
            var spanDateOfBirth = BirthDate - dt1900;

            var span = spanCurrent - spanDateOfBirth;
            return span.TotalMilliseconds < AgeOfAdult;
        }

        public Data.Models.User ToUser()
        {
            return new Data.Models.User
            {
                CreateDate = DateTime.Now,
                ModifyDate = DateTime.Now,
                IsActive = true,
                DateofBirth = BirthDate,
                Email = Email,
                Name = Name,
                Surname = Surname,
                Role_Id = IsAdministrator ? (int)Data.Enums.Role.Admin : (int)Data.Enums.Role.Employee,
                Password = Encrypt.EncryptPassword("qwerty1")
            };
        }

        public Data.Models.Employee ToEmployee(Data.Models.User user)
        {
            return new Data.Models.Employee
            {
                CreateDate = DateTime.Now,
                ModifyDate = DateTime.Now,
                IsActive = true,
                IsVerified = true,
                Name = Name,
                Surname = Surname,
                Pesel = Pesel,
                Phone = Phone,
                Position_Id = PositionId,
                Salary = Salary ?? 0,
                Address = AddressEdit.ToNewAddress(),
                User = user
            };
        }
    }
}