﻿using System.Collections.Generic;

namespace CarService.Web.Services.Car
{
    public interface ICarsService
    {
        IEnumerable<Data.Models.Car> Cars { get; }
    }
}