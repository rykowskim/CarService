using CarService.Data.Models;
using System.Collections.Generic;

namespace CarService.Data.Services.User
{
    public partial class UserService : IUserService
    {
        private CarServiceContext dbContext = new CarServiceContext();

        public IEnumerable<Models.User> Users
        {
            get { return dbContext.User; }
        }

        public void Create(Data.Models.User user)
        {
            dbContext.User.Add(user);
            dbContext.SaveChanges();
        }
    }
}