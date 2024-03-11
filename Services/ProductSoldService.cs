using Web_API_Proyecto_final.models;
using Web_API_Proyecto_final.DTOs;
using Web_API_Proyecto_final.Database;
namespace Web_API_Proyecto_final.Services
{
    public class ProductSoldService
    {
        private readonly DatabaseContext context;
        public ProductSoldService(DatabaseContext dbcontext)
        {
            this.context = dbcontext;
        }
        public List<ProductSold> GetAllProductSold()
        {
            return this.context.ProductSold.ToList();
        }
    }
}
