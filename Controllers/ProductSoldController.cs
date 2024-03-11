using Microsoft.AspNetCore.Mvc;
using Web_API_Proyecto_final.models;
using Web_API_Proyecto_final.DTOs;
using Web_API_Proyecto_final.Services;

namespace Web_API_Proyecto_final.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductSoldController : Controller
    {
        private readonly ProductSoldService productSoldService; 

        public ProductSoldController(ProductSoldService productSoldService)
        {
            this.productSoldService = productSoldService;
        }

        [HttpGet]
        public List<ProductSold> GetProductSoldList()
        {
            return this.productSoldService.GetAllProductSold();
        }
    }
}

