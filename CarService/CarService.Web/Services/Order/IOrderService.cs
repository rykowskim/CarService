using CarService.Web.ViewModels.Order;
using System.Collections.Generic;

namespace CarService.Web.Services.Order
{
    public interface IOrderService
    {
        IEnumerable<Data.Models.Order> Orders { get; }
        Create GetCreateViewModel(Data.Models.Order order);
        void Create(Data.Models.Order order);
        void Update(Data.Models.Order order);
    }
}