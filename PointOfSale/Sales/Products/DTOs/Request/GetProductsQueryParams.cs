using System.ComponentModel.DataAnnotations;

namespace PointOfSale.Sales.Products.DTOs.Request
{
    public record GetProductsQueryParams
    {
        [StringLength(100, ErrorMessage = "Category must be less than 100 characters.")]
        public string? Category { get; set; }

        [StringLength(100, ErrorMessage = "Supplier must be less than 100 characters.")]
        public string? Supplier { get; set; }

        [StringLength(100, ErrorMessage = "Purchase must be less than 100 characters.")]
        public string? Purchase { get; set; }

        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Price must be a valid number with up to two decimal places.")]
        public string? Price { get; set; }

        [StringLength(50, ErrorMessage = "OrderBy must be less than 50 characters.")]
        public string? OrderBy { get; set; }

        [RegularExpression(@"^(asc|desc)$", ErrorMessage = "OrderDirection must be 'asc' or 'desc'.")]
        public string? OrderDirection { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Page must be greater than 0.")]
        public int? Page { get; set; } = 1;

        [Range(1, int.MaxValue, ErrorMessage = "Page must be greater than 0.")]
        public int? Limit { get; set; } = 20;
    }

}
