using System;
using System.Collections.Generic;

namespace PointOfSale.Models;

public partial class Promotion
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public double PorcentageDiscount { get; set; }

    public string? Description { get; set; }

    public string ProductBarcode { get; set; } = null!;

    public bool Active { get; set; }

    public virtual ProductsItem ProductBarcodeNavigation { get; set; } = null!;
}
