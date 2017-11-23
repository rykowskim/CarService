using CarService.Data.Models;
using System.Collections.Generic;

namespace CarService.Web.Services.Car
{
    public class CarsService : ICarsService
    {
        private CarServiceContext dbContext = new CarServiceContext();

        public IEnumerable<Data.Models.Car> Cars => dbContext.Car;
    }
}