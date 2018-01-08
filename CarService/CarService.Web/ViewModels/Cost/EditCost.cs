using CarService.Web.ViewModels.Order;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarService.Web.ViewModels.Cost
{
    public class EditCost
    {
        public int Id { get; set; }

        [DisplayName("Cena"), Required(ErrorMessage = "Pole Cena jest wymagane")]
        public decimal? Price { get; set; }

        [DisplayName("Wymiana"), Required(ErrorMessage = "Pole Wymiana jest wymagane")]
        public string Description { get; set; }

        public EditOrder Order { get; set; }

        public string ReturnUrl { get; set; }

        private readonly Data.Models.Cost _cost;

        public EditCost(Data.Models.Cost cost)
        {
            _cost = cost;
            if (cost.Id != 0)
            {
                Id = cost.Id;
                Price = cost.Price;
                Description = cost.Description;
            }
        }
        
        public Data.Models.Cost ToModel()
        {
            if (_cost.Id == 0)
            {
                _cost.CreateDate = DateTime.Now;
                _cost.IsActive = true;
            }

            _cost.ModifyDate = DateTime.Now;
            _cost.Price = Price.Value;
            _cost.Description = Description;
            _cost.Order = new Data.Models.Order { Id = Order.Id };

            return _cost;
        }
    }
}