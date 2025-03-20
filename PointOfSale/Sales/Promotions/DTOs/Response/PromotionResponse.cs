namespace PointOfSale.Sales.Promotions.DTOs.Response
{
    public record PromotionResponse
    {
        public int Id { get; init; }

        public string Name { get; init; } = null!;

        public double PorcentageDiscount { get; init; }

        public string? Description { get; init; }

        public bool Active { get; init; }
    }
}
