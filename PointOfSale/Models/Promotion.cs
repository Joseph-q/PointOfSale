using System;
using System.Collections.Generic;

namespace PointOfSale.Models;

public partial class Promotion
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public double PorcentageDiscount { get; set; }

    public string? Description { get; set; }

    public bool Active { get; set; }

    public virtual ICollection<ProductsItem> ProductBarcodes { get; set; } = new List<ProductsItem>();
}
