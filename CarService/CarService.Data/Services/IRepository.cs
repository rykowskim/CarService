using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarService.Data.Services
{
    public interface ICarRepository
    {
        IEnumerable<Models.Car> Cars { get; }
    }
}