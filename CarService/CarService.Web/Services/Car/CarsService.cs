using CarService.Data.Models;
using System.Collections.Generic;

namespace CarService.Web.Services.Car
{
    public class CarsService : ICarsService
    {
        private CarServiceContext dbContext = new CarServiceContext();

        public IEnumerable<Data.Models.Car> Cars => dbContext.Car;

        public void Create(Data.Models.Car car)
        {
            dbContext.Entry(car.Customer).State = System.Data.Entity.EntityState.Unchanged;
            dbContext.Car.Add(car);
            dbContext.SaveChanges();
        }
    }
}