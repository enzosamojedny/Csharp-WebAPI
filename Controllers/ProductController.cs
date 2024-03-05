using Microsoft.AspNetCore.Mvc;
using Web_API_Proyecto_final.models;
using Web_API_Proyecto_final.DTOs;
using Web_API_Proyecto_final.Services;
namespace Web_API_Proyecto_final.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProductController : Controller
    {
        private ProductService productService;
        public ProductController(ProductService productService)
        {
            this.productService = productService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<ProductDTO>> GetProducts()
        {
            var products = this.productService.GetAllProducts();
            return Ok(products);
        }
        [HttpPost]
        public IActionResult AddNewProduct([FromBody] ProductDTO product)
        {
            if (this.productService.AddProduct(product))
            {
                return base.Ok(product);

            }
            else
            {
                return base.Conflict(new { message = "Could not add a new product" });
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProductById(int id)
    {
            if (id>0)
            {
                if (this.productService.DeleteProductById(id))
                {
                    return base.Ok(new { status = 200, message = "Product deleted successfully" });
                }
                //else
                    return base.Conflict(new { message = $"Could not delete product with ID {id}" }); 
            }
                return base.BadRequest(new { status = 400, message="Product ID is invalid" });
    }
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, ProductDTO productDTO)
        {
            if (id > 0)
            {
                if (this.productService.UpdateProduct(id,productDTO))
                {
                    return base.Ok(new { status = 200, message = "Product updated successfully", productDTO });
                }
                else
                {
                    return base.Conflict(new { message = $"Could not update product with ID {id}" });
                }
            }
            return base.BadRequest(new { status = 400, message = "Product ID is invalid" });
        }

    }
}
