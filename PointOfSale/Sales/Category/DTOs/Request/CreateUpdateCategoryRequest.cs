using System.ComponentModel.DataAnnotations;

namespace PointOfSale.Sales.Category.DTOs.Request
{
    public record CreateUpdateCategoryRequest
    {
        [Required]
        public string Name { get; init; } = null!;
    }
}
