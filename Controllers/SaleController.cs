using Microsoft.AspNetCore.Mvc;
using Web_API_Proyecto_final.DTOs;
using Web_API_Proyecto_final.models;
using Web_API_Proyecto_final.Services;

namespace Web_API_Proyecto_final.Controllers
{
    [ApiController]
    [Route("/api/sales")]
    public class SaleController : Controller
    {
        private readonly SaleService saleService;

        public SaleController(SaleService saleService)
        {
            this.saleService = saleService;
        }

        [HttpGet]
        public List<Sale> GetSaleList()
        {
            return this.saleService.GetAllSales();
        }
        [HttpPost]
        public IActionResult AddNewSale([FromBody] SaleDTO sale)
        {
            if (this.saleService.AddSale(sale))
            {
                return base.Ok(sale);

            }
            else
            {
                return base.Conflict(new { message = "Could not register a new sale" });
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSaleById(int id)
        {
            if (id > 0)
            {
                if (this.saleService.DeleteSaleById(id))
                {
                    return base.Ok(new { status = 200, message = "Sale deleted successfully" });
                }

                return base.Conflict(new { message = $"Could not delete sale with ID {id}" });
            }
            return base.BadRequest(new { status = 400, message = "Sale ID is invalid" });
        }
        [HttpPut("{id}")]
        public IActionResult UpdateSale(int id, SaleDTO saleDTO)
        {
            if (id > 0)
            {
                if (this.saleService.UpdateSale(id, saleDTO))
                {
                    return base.Ok(new { status = 200, message = "Sale updated successfully", saleDTO });
                }
                else
                {
                    return base.Conflict(new { message = $"Could not update sale with ID {id}" });
                }
            }
            return base.BadRequest(new { status = 400, message = "Sale ID is invalid" });
        }
    }
}
