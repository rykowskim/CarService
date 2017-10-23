using System.Linq;

namespace CarService.Data.Services.User
{
    public partial class UserService
    {
        public bool IsExistsEmail(string email)
        {
            return Users.Where(x => x.Email.Equals(email)).Any();
        }
    }
}