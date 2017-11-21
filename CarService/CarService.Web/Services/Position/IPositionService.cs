using System.Collections.Generic;

namespace CarService.Web.Services.Position
{
    public interface IPositionService
    {
        IEnumerable<Data.Models.Position> Positions { get; }
    }
}