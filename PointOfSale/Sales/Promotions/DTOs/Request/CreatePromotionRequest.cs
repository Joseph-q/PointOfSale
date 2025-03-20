using System.ComponentModel.DataAnnotations;

namespace PointOfSale.Sales.Promotions.DTOs.Request
{
    public record CreatePromotionRequest : IValidatableObject
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; init; } = null!;

        [Required]
        [Range(0, 100)]
        public double PorcentageDiscount { get; init; }

        [MaxLength(100)]
        public string? Description { get; init; }

        public DateTimeOffset? StartAt { get; init; }

        public DateTimeOffset? EndAt { get; init; }

        [Required]
        public bool Active { get; init; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (EndAt <= StartAt)
            {
                yield return new ValidationResult("End date must be greater than the start date.", ["EndAt"]);
            }
        }
    }
}
