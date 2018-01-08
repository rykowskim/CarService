using CarService.Data.Models;
using System.Collections.Generic;

namespace CarService.Web.Services.Cost
{
    public class CostService : ICostService
    {
        private CarServiceContext dbContext = new CarServiceContext();

        public IEnumerable<Data.Models.Cost> Costs => dbContext.Cost;

        public void Create(Data.Models.Cost cost)
        {
            dbContext.Entry(cost.Order).State = System.Data.Entity.EntityState.Unchanged;
            dbContext.Cost.Add(cost);
            dbContext.SaveChanges();
        }

        public void Update(Data.Models.Cost cost)
        {
            dbContext.Entry(cost).State = System.Data.Entity.EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}