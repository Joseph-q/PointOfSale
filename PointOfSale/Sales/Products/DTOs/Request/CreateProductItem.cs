using System.ComponentModel.DataAnnotations;

namespace PointOfSale.Sales.Products.DTOs.Request
{
    public record CreateProductItem
    {
        [Required]
        [StringLength(20)]
        public required string Name { get; set; }

        [Required]
        [StringLength(50)]
        public required string Description { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public required decimal Price { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int SupplierId { get; set; }
    }
}
