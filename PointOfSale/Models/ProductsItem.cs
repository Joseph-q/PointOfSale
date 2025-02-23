using System;
using System.Collections.Generic;

namespace PointOfSale.Models;

public partial class ProductsItem
{
    public string Barcode { get; set; } = null!;

    public int? CategoryId { get; set; }

    public int? SupplierId { get; set; }

    public string? Name { get; set; }

    public DateOnly? ExpiredDate { get; set; }

    public DateOnly? DateAdded { get; set; }

    public double? Price { get; set; }

    public int? Stock { get; set; }

    public int? Sold { get; set; }

    public virtual ProductCategory? Category { get; set; }

    public virtual ICollection<Promotion> Promotions { get; set; } = new List<Promotion>();

    public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; } = new List<PurchaseDetail>();
}
