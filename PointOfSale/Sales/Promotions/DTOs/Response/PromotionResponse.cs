namespace PointOfSale.Sales.Promotions.DTOs.Response
{
    public class PromotionResponse
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public double PorcentageDiscount { get; set; }

        public string? Description { get; set; }

        public bool Active { get; set; }
    }
}
