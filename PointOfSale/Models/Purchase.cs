using System;
using System.Collections.Generic;

namespace PointOfSale.Models;

public partial class Purchase
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public DateOnly? Date { get; set; }

    public TimeOnly? Time { get; set; }

    public double? TotalAmount { get; set; }

    public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; } = new List<PurchaseDetail>();

    public virtual User? User { get; set; }
}
