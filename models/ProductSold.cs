using System;
using Web_API_Proyecto_final.DTOs;

namespace Web_API_Proyecto_final.models
{
    public partial class ProductSold
    {
        public int Id { get; set; }
        public int Stock { get; set; }
        public int ProductId { get; set; }
        public int SaleId { get; set; }

        public virtual Product IdProductNavigation { get; set; } = null!;
        public virtual Sale IdSaleNavigation { get; set; } = null!;
    }
}
