using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarService.Web.ViewModels.User
{
    public class RegisterCreateViewModel : IValidatableObject
    {
        [DisplayName("Email")]
        [Required(ErrorMessage = "Pole Email jest wymagane")]
        public string Email { get; set; }

        [DisplayName("Hasło")]
        [Required(ErrorMessage = "Pole Hasło jest wymagane")]
        public string Password { get; set; }

        [DisplayName("Powtórz hasło")]
        [Compare("Password")]
        [Required(ErrorMessage = "Pole Powtórz hasło jest wymagane")]
        public string RepeatPassword { get; set; }

        [DisplayName("Imię")]
        [Required(ErrorMessage = "Pole Imię jest wymagane")]
        public string Name { get; set; }

        [DisplayName("Nazwisko")]
        [Required(ErrorMessage = "Pole Nazwisko jest wymagane")]
        public string Surname { get; set; }

        [DisplayName("Data urodzenia")]
        [Required(ErrorMessage = "Pole Data urodzenia jest wymagane")]
        public DateTime DateOfBirth { get; set; }

        [DisplayName("PESEL")]
        [Required(ErrorMessage = "Pole PESEL jest wymagane")]
        public string Pesel { get; set; }

        [DisplayName("Phone")]
        public string Phone { get; set; }


        public IEnumerable<ValidationResult> Validate (ValidationContext validationContext)
        {
            if (!Email.Contains("@"))
                yield return new ValidationResult("Błędny adres email", new[] { "Email" });

            if (Password.Length < 6)
                yield return new ValidationResult("Hasło musi zawierać minimum 6 znaków", new[] { "Password" });

            if (Pesel.Length != 11) //todo sprawdzenie czy nie występuje jakiś znak
                yield return new ValidationResult("Niepoprawny PESEL", new[] { "Pesel" });

            //if (DateTime.Now.AddYears(-18). DateOfBirth) 18 lat = 567648000000 ms
            //    yield return new ValidationResult("Osoba niepełnoletnia" + DateOfBirth + " " + DateTime.Now.AddYears(-18), new[] { "DateOfBirth" });
        }

        public Data.Models.User ToUser()
        {
            return new Data.Models.User
            {
                CreateDate = DateTime.Now,
                ModifyDate = DateTime.Now,
                IsActive = true,
                Email = Email,
                Password = Password,
                Name = Name,
                Surname = Surname,
                DateofBirth = DateOfBirth,
                Pesel = Pesel
            };
        }
    }
}