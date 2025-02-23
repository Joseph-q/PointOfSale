using System;
using System.Collections.Generic;

namespace PointOfSale.Models;

public partial class ProductCategory
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<ProductsItem> ProductsItems { get; set; } = new List<ProductsItem>();
}
