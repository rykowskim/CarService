using System.Collections.Generic;
using System.Web.Mvc;

namespace CarService.Data.Services.User
{
    public interface IUserService 
    {
        IEnumerable<Models.User> Users { get; }
        void Create(Models.User user);

        bool IsExistsEmail(string email);
    }
}