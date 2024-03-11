namespace Web_API_Proyecto_final.DTOs
{
    public class ProductService
    {
        public int Id { get; set; }

        public string Description { get; set; } = null!;

        public double BuyPrice { get; set; }

        public double SellPrice { get; set; }

        public decimal Stock { get; set; }

        public decimal TotalProduct { get; set; }

        public string Category { get; set; } = null!;

        public string Name { get; set; } = null!;

        public int? UsersId { get; set; }
    }
}
