using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarService.Web.Services.User
{
    public interface IUserService
    {
        IEnumerable<Data.Models.User> Users { get; }
        void Create(Data.Models.User user);

        bool IsExists(string email);
    }
}