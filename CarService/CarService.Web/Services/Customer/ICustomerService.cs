﻿using CarService.Web.ViewModels.Customer;
using System.Collections.Generic;

namespace CarService.Web.Services.Customer
{
    public interface ICustomerService
    {
        IEnumerable<Data.Models.Customer> Customers { get; }
        void Create(Data.Models.Customer customer);
        IEnumerable<ResultItem> Search(CustomerListFilters filter);
    }
}