using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarService.Web.ViewModels
{
    public class RegisterCreateViewModel
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
        [Required(ErrorMessage ="Pole Data urodzenia jest wymagane")]
        public DateTime DateOfBirth { get; set; }
    }
}