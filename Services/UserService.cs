using Web_API_Proyecto_final.Database;
using Web_API_Proyecto_final.DTOs;
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
        public bool CreateUser(UserDTO user)
        {
            return true;
        }
        public bool DeleteUserById(int id)
        {
            User? user = this.context.Users.Where(p => p.Id == id).FirstOrDefault();
            if (user != null)
            {
                this.context.Remove(user);
                this.context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool UpdateUser(int id, UserDTO userDTO)
        {
            User? user = this.context.Users.Where(p => p.Id == id).FirstOrDefault();

            if (user != null)
            {
                user.Name = userDTO.Name ?? user.Name;
                user.LastName = userDTO.LastName ?? user.LastName;
                user.Username = userDTO.Username ?? user.Username;
                user.Password = userDTO.Password ?? user.Password;
                user.Email = userDTO.Email;

                this.context.Update(user);
                this.context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
