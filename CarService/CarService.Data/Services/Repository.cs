using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarService.Data.Services
{
    public class CarRepository : ICarRepository
    {
        private Models.CarServiceContext dbContext = new Models.CarServiceContext();

        public IEnumerable<Models.Car> Cars
        {
            get { return dbContext.Car; }
        }
    }
}