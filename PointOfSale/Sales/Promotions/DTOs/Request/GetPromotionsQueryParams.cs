namespace PointOfSale.Sales.Promotions.DTOs.Request
{
    public record GetPromotionsQueryParams
    {
        public bool? Active { get; set; }
    }
}
