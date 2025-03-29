using System.ComponentModel.DataAnnotations;

namespace PointOfSale.Sales.Purchases.DTOs.Request
{

    public record RealicePurchaseRequest
    {
        [MinLength(1)]
        public required List<ProductToSaleRequest> Purchase { get; init; }

        [Range(.001, 100)]
        public float PorcentageDiscount { get; init; } = 0;


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Purchase == null || !Purchase.Any())
            {
                yield return new ValidationResult("The product list is empty", new[] { nameof(Purchase) });
            }
        }
    }


    public record ProductToSaleRequest
    {
        [Required]
        [MaxLength(50)]
        public required string ProductBarcode { get; init; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; init; }
    }

}
