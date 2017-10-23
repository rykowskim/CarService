using CarService.Data.Models;
using System.Collections.Generic;

namespace CarService.Data.Services.Car
{
    public class CarService : ICarService
    {
        private CarServiceContext dbContext = new CarServiceContext();
        
        public IEnumerable<Models.Car> Cars
        {
            get { return dbContext.Car; }
        }
    }
}