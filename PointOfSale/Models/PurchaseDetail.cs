using System;
using System.Collections.Generic;

namespace PointOfSale.Models;

public partial class PurchaseDetail
{
    public int Id { get; set; }

    public string? ProductBarcode { get; set; }

    public int? PurchaseId { get; set; }

    public int? Quantity { get; set; }

    public virtual ProductsItem? ProductBarcodeNavigation { get; set; }

    public virtual Purchase? Purchase { get; set; }
}
