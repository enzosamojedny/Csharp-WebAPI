using Web_API_Proyecto_final.models;

namespace Web_API_Proyecto_final.DTOs
{
    public class ProductSoldDTO
    {
        public int Stock { get; set; }
        public int ProductId { get; set; }
        public int SaleId { get; set; }
    }
}
