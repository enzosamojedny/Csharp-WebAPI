using Web_API_Proyecto_final.Database;
using Web_API_Proyecto_final.models;

namespace Web_API_Proyecto_final.Services
{
    public class UserService
    {
        private readonly DatabaseContext context;
        public UserService(DatabaseContext dbcontext)
        {
            this.context = dbcontext;
        }

        public List<User> GetAllUsers()
        {
            return this.context.Users.ToList();
        }
    }
}
