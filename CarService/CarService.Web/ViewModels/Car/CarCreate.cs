using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarService.Web.ViewModels.Car
{
    public class CarCreate
    {
        [DisplayName("Marka")]
        [Required(ErrorMessage = "Marka jest wymagana")]
        public string Mark { get; set; }

        [DisplayName("Model")]
        [Required(ErrorMessage = "Model jest wymagana")]
        public string Model { get; set; }

        [DisplayName("Rok produckji")]
        [Required(ErrorMessage = "Rok produkcji jest wymagany")]
        public int? ProductYear { get; set; } 

        [DisplayName("Pojemność silnika")]
        [Required(ErrorMessage = "Pojemność silnika jest wymagana")]
        public decimal? Engine { get; set; }  

        [DisplayName("Numer rejestracyjny")]
        [Required(ErrorMessage = "Numer rejestracyjny jest wymagany")]
        public string RegisterNumber { get; set; }

        [DisplayName("Właściciel")]
        [Required(ErrorMessage = "Właściciel jest wymagany")]
        public int CustomerId { get; set; }
        public IEnumerable<SelectListItem> Customers { get; set; } 

        public Data.Models.Car ToCar()
        {
            return new Data.Models.Car
            {
                CreateDate = DateTime.Now,
                ModifyDate = DateTime.Now,
                IsActive = true,
                Mark = Mark,
                Model = Model,
                Engine = Engine.Value,
                ProductYear = ProductYear.Value,
                RegisterNumber = RegisterNumber,
                Customer = new Data.Models.Customer { Id = CustomerId }
            };
        }
    }
}