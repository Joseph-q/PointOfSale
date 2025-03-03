using System.ComponentModel.DataAnnotations;

namespace PointOfSale.Sales.Category.DTOs.Request
{
    public class GetCategoriesQueryParams
    {
        [Range(1, 200, ErrorMessage = "Page must be greater between 1 and 200")]
        public int? Page { get; set; } = 1;

        [Range(5, 1000, ErrorMessage = "Page must be between 5 an 1,000")]
        public int? Limit { get; set; } = 20;

        [MaxLength(20, ErrorMessage = "OrderBy must be less than 20 characters.")]
        public string? OrderBy { get; set; }

        [RegularExpression(@"^(asc|desc)$", ErrorMessage = "OrderDirection must be 'asc' or 'desc'.")]
        public string? OrderDirection { get; set; }

    }
}
