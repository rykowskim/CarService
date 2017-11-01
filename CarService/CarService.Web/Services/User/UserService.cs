using CarService.Data.Models;
using System.Collections.Generic;

namespace CarService.Web.Services.User
{
    public partial class UserService : IUserService
    {
        private CarServiceContext dbContext = new CarServiceContext();

        public IEnumerable<Data.Models.User> Users
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