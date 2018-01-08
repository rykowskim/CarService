using System.Collections.Generic;

namespace CarService.Web.Services.Cost
{
    public interface ICostService
    {
        IEnumerable<Data.Models.Cost> Costs { get; }
        void Create(Data.Models.Cost cost);
        void Update(Data.Models.Cost cost);
    }
}