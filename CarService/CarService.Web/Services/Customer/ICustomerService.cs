﻿using System.Collections.Generic;

namespace CarService.Web.Services.Customer
{
    public interface ICustomerService
    {
        IEnumerable<Data.Models.Customer> Customers { get; }
        
    }
}