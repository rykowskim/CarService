using CarService.Data.Models;
using System.Collections.Generic;

namespace CarService.Web.Services.Position
{
    public class PositionService : IPositionService
    {
        private CarServiceContext dbContext = new CarServiceContext();

        public IEnumerable<Data.Models.Position> Positions => dbContext.Position;
    }
}