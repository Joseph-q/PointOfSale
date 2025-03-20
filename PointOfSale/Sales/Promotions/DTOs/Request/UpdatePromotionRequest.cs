using System.ComponentModel.DataAnnotations;

namespace PointOfSale.Sales.Promotions.DTOs.Request
{
    public record UpdatePromotionRequest
    {
        [MaxLength(50)]
        public string? Name { get; init; }

        [Range(0, 100)]
        public double? PorcentageDiscount { get; init; }

        [MaxLength(100)]
        public string? Description { get; init; }

        public bool? Active { get; init; }

        [MinLength(1, ErrorMessage = "ProductsIDs array must have between 1 and 100 product IDs.")]
        [MaxLength(100, ErrorMessage = "ProductsIDs array must have between 1 and 100 product IDs.")]
        public string[]? ProductsIDs { get; init; }
    }
}
