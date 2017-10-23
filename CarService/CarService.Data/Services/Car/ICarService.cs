using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarService.Data.Services.Car
{
    public interface ICarService
    {
        IEnumerable<Models.Car> Cars { get; }
    }
}