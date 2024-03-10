using Web_API_Proyecto_final.models;

namespace Web_API_Proyecto_final.DTOs
{
    public class SaleDTO
    {
        public int Id { get; set; }

        public string Comments { get; set; } = null!;

        public string UserId { get; set; } = null!;

        public int? UsersId { get; set; }

        public string? SalesId { get; set; }

        public virtual Sale? Sales { get; set; }

        public virtual User? Users { get; set; }
    }
}
