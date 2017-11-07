using CarService.Web.Mvc.Other;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

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
        
        
        public IEnumerable<ValidationResult> Validate (ValidationContext validationContext)
        {
            if (Email.Length < 6 && !Email.Contains("@"))
                yield return new ValidationResult("Niepoprawny adres email", new[] { "Email" });

            if (Password.Length < 6)
                yield return new ValidationResult("Hasło musi zawierać minimum 6 znaków", new[] { "Password" });
            
            if (IsValidBirthDay()) 
                yield return new ValidationResult("Musisz mieć ukończone 18 lat", new[] { "DateOfBirth" });

            if (!RepeatPassword.Equals(Password))
                yield return new ValidationResult("Hasła różnią się", new[] { "RepeatPassword" });
        }

        private bool IsValidBirthDay()
        {
            const long AgeOfAdult = 567648000000;

            var dt1900 = new DateTime(1900, 1, 1);
            var current = DateTime.Now;
            var spanCurrent = current - dt1900;
            var spanDateOfBirth = DateOfBirth - dt1900;

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
                Email = Email,
                Password = Encrypt.EncryptPassword(Password),
                Name = Name,
                Surname = Surname,
                DateofBirth = DateOfBirth
            };
        }
    }
}