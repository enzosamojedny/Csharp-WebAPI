using System;
using System.Collections.Generic;

namespace Web_API_Proyecto_final.models;

public partial class Sale
{
    public int Id { get; set; }

    public string Comments { get; set; } = null!;

    public int UserId { get; set; }

    public int? UsersId { get; set; }

    public int? SalesId { get; set; }

    public virtual ICollection<Sale> InverseSales { get; set; } = new List<Sale>();

    public virtual Sale? Sales { get; set; }

    public virtual User? Users { get; set; }
    public virtual ICollection<ProductSold> ProductSold { get; set; } = new List<ProductSold>();

}
