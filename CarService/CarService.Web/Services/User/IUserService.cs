using System.Collections.Generic;

namespace CarService.Web.Services.User
{
    public interface IUserService
    {
        IEnumerable<Data.Models.User> Users { get; }

        Data.Models.User Get(int id);
        void Create(Data.Models.User user);
        bool IsExists(string email);

    }
}