using System.Linq;

namespace CarService.Web.Services.User
{
    public partial class UserService
    {
        public bool IsExists(string email)
        {
            return Users.Where(x => x.Email.Equals(email)).Any();
        }
    }
}