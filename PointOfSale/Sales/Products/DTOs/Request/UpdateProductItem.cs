using System.ComponentModel.DataAnnotations;

namespace PointOfSale.Sales.Products.DTOs.Request
{
    public record UpdateProductItem
    {
        [StringLength(20)]
        public required string Name { get; init; }

        [StringLength(50)]
        public required string Description { get; init; }

        [Range(1, int.MaxValue)]
        public int CategoryId { get; init; }

        [Range(0.01, double.MaxValue)]
        public required decimal Price { get; init; }

        [Range(1, int.MaxValue)]
        public int? SupplierId { get; init; }
    }
}
