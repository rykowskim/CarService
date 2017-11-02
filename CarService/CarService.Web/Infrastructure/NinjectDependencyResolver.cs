using CarService.Web.Services;
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
        }
    }
}