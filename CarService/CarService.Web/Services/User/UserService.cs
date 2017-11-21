using CarService.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace CarService.Web.Services.User
{
    public partial class UserService : IUserService
    {
        private CarServiceContext dbContext = new CarServiceContext();

        public IEnumerable<Data.Models.User> Users
        {
            get { return dbContext.User; }
        }

        public Data.Models.User Get(int id)
        {
            return Users.Where(x => x.Id == id && x.IsActive).FirstOrDefault();
        }

        public void Create(Data.Models.User user)
        {
            dbContext.User.Add(user);
            dbContext.SaveChanges();
        }
    }
}