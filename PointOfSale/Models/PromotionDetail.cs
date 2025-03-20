using System;
using System.Collections.Generic;

namespace PointOfSale.Models;

public partial class PromotionDetail
{
    public string? ProductBarcode { get; set; }

    public int? PromotionId { get; set; }
}
