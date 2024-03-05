using Microsoft.AspNetCore.Mvc;

namespace Web_API_Proyecto_final.Controllers
{
    [ApiController]
    [Route("/api/admin")]
    public class NameController : Controller
    {
        List<string> list;
        [HttpGet("getName")]
        public string GetName()
        {
            return "Enzo Samojedny";
        }
        [HttpGet("list/{id}")]
        public ActionResult<string> GetNameById(int id)
        {
            if(id < 0|| id>=list.Count)
            {
                return base.BadRequest(new { message = $"Id cannot be a negative or bigger than {this.list.Count}", status = 400 });
            }
            return this.list[id];
        }
    }
}
