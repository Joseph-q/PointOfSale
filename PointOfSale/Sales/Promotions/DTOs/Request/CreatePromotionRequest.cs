using System.ComponentModel.DataAnnotations;

namespace PointOfSale.Sales.Promotions.DTOs.Request
{
    public record CreatePromotionRequest
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; init; } = null!;

        [Required]
        [Range(0, 100)]
        public double PorcentageDiscount { get; init; }

        [MaxLength(100)]
        public string? Description { get; init; }

        [Required]
        public bool Active { get; init; }
    }
}
