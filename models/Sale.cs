using System;
using System.Collections.Generic;

namespace Web_API_Proyecto_final.models;

public partial class Sale
{
    public string Id { get; set; } = null!;

    public string Comments { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public int? UsersId { get; set; }

    public string? SalesId { get; set; }

    public virtual ICollection<Sale> InverseSales { get; set; } = new List<Sale>();

    public virtual Sale? Sales { get; set; }

    public virtual User? Users { get; set; }
}
