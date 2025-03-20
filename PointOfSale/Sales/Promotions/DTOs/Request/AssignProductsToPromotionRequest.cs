using System.ComponentModel.DataAnnotations;

namespace PointOfSale.Sales.Promotions.DTOs.Request
{
    public record AssignProductsToPromotionRequest
    {
        [Required(ErrorMessage = "ProductsIDs cannot be null or empty.")]
        [MinLength(1, ErrorMessage = "At least one ProductID must be provided.")]
        [MaxLength(100, ErrorMessage = "ProductsIDs array must have between 1 and 100 product IDs.")]
        public string[] ProductsIDs { get; init; } = [];
    }
}
