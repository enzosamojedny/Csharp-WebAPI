using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Web_API_Proyecto_final.models;
using System.Collections.Generic;
using Web_API_Proyecto_final.Database;
using Web_API_Proyecto_final.Services;
using Web_API_Proyecto_final.DTOs;
namespace Web_API_Proyecto_final.Controllers
{
    [ApiController]
    [Route("/api/users")]
    public class UserController : Controller
    {
        private readonly UserService userService;

        public UserController(UserService userService)
        {
            this.userService = userService;
        } 

        [HttpGet]
        public List<User> GetUserList()
        {
            return this.userService.GetAllUsers();
        }
        [HttpPost]
        public IActionResult AddNewProduct([FromBody] UserDTO user)
        {
            if (this.userService.CreateUser(user))
            {
                return base.Ok(user);

            }
            else
            {
                return base.Conflict(new { message = "Could not register a new user" });
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteUserById(int id)
        {
            if (id > 0)
            {
                if (this.userService.DeleteUserById(id))
                {
                    return base.Ok(new { status = 200, message = "User deleted successfully" });
                }
                //else
                return base.Conflict(new { message = $"Could not delete user with ID {id}" });
            }
            return base.BadRequest(new { status = 400, message = "User ID is invalid" });
        }
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, UserDTO userDTO)
        {
            if (id > 0)
            {
                if (this.userService.UpdateUser(id, userDTO))
                {
                    return base.Ok(new { status = 200, message = "User updated successfully", userDTO });
                }
                else
                {
                    return base.Conflict(new { message = $"Could not update user with ID {id}" });
                }
            }
            return base.BadRequest(new { status = 400, message = "User ID is invalid" });
        }
    }
}
