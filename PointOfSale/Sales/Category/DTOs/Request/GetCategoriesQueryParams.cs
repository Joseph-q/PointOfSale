using PointOfSale.Models;
using PointOfSale.Shared.Attributes;
using System.ComponentModel.DataAnnotations;

namespace PointOfSale.Sales.Category.DTOs.Request
{
    public record GetCategoriesQueryParams
    {
        [Range(1, int.MaxValue, ErrorMessage = "Page must be greater between 1 and 200")]
        public int Page { get; init; } = 1;

        [Range(5, 100, ErrorMessage = "Page must be between 5 an 100")]
        public int Limit { get; init; } = 20;

        [ValidProperty(typeof(ProductCategory))]
        [MaxLength(20, ErrorMessage = "OrderBy must be less than 20 characters.")]
        public string OrderBy { get; init; } = "Id";

        [RegularExpression(@"^(asc|desc)$", ErrorMessage = "OrderDirection must be 'asc' or 'desc'.")]
        public string? OrderDirection { get; init; }

    }
}
