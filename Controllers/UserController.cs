using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Web_API_Proyecto_final.models;
using System.Collections.Generic;
using Web_API_Proyecto_final.Database;
using Web_API_Proyecto_final.Services;
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
    }
}
