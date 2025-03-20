using System.ComponentModel.DataAnnotations;

namespace PointOfSale.Sales.Products.DTOs.Request
{
    public record GetProductsQueryParams
    {
        [Range(1, int.MaxValue)]
        public int? CategoryId { get; init; }

        [Range(1, int.MaxValue)]
        public int? SupplierId { get; init; }

        [Range(1, int.MaxValue)]
        public int? PurchaseId { get; init; }

        [Range(0.01, double.MaxValue)]
        public double? Price { get; init; }

        [MaxLength(20, ErrorMessage = "OrderBy must be less than 20 characters.")]
        public string? OrderBy { get; init; }

        [RegularExpression(@"^(asc|desc)$", ErrorMessage = "OrderDirection must be 'asc' or 'desc'.")]
        public string? OrderDirection { get; init; }

        [Range(1, 200, ErrorMessage = "Page must be greater between 1 and 200")]
        public int? Page { get; init; } = 1;

        [Range(5, 1000, ErrorMessage = "Page must be between 5 an 1,000")]
        public int? Limit { get; init; } = 20;
    }

}
