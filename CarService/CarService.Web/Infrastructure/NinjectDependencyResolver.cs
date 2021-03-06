﻿using CarService.Web.Services;
using CarService.Web.Services.Address;
using CarService.Web.Services.Car;
using CarService.Web.Services.Cost;
using CarService.Web.Services.Customer;
using CarService.Web.Services.Employee;
using CarService.Web.Services.Order;
using CarService.Web.Services.Position;
using CarService.Web.Services.User;
using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CarService.Web.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver 
    {
         private IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            _kernel = kernel;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            _kernel.Bind<IUserService>().To<UserService>();
            _kernel.Bind<IAuthenticationService>().To<AuthenticationService>();
            _kernel.Bind<IEmployeeService>().To<EmployeeService>();
            _kernel.Bind<IPositionService>().To<PositionService>();
            _kernel.Bind<IAddressService>().To<AddressService>();
            _kernel.Bind<ICustomerService>().To<CustomerService>();
            _kernel.Bind<IOrderService>().To<OrderService>();
            _kernel.Bind<ICarsService>().To<CarsService>();
            _kernel.Bind<ICostService>().To<CostService>();
        }
    }
}