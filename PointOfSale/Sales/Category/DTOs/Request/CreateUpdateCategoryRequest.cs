using System.ComponentModel.DataAnnotations;

namespace PointOfSale.Sales.Category.DTOs.Request
{
    public class CreateUpdateCategoryRequest
    {
        [Required]
        public String Name { get; set; } = null!;
    }
}
