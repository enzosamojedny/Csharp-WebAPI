using System;
using System.Collections.Generic;

namespace Web_API_Proyecto_final.models;

public partial class Product
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

    public virtual User IdUserNavigation { get; set; } = null!;
    public virtual ICollection<Sale> Sale { get; set; }
    public virtual ICollection<ProductSold> ProductSold { get; set; } = new List<ProductSold>();

}
