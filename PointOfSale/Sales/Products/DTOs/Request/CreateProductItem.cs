using System.ComponentModel.DataAnnotations;

namespace PointOfSale.Sales.Products.DTOs.Request
{
    public record CreateProductItem
    {

        [Required]
        [MaxLength(50)]
        public required string Barcode { get; init; }

        [Required]
        [MaxLength(50)]
        public required string Name { get; init; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public required double Price { get; init; }


        [Range(1, int.MaxValue)]
        public int? Stock { get; init; }

    }
}
