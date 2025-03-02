using System.ComponentModel.DataAnnotations;

namespace PointOfSale.Sales.Products.DTOs.Request
{
    public record CreateProductItem
    {

        [Required]
        [MaxLength(50)]
        public required string Barcode { get; set; }

        [Required]
        [MaxLength(50)]
        public required string Name { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public required double Price { get; set; }


        [Range(1, int.MaxValue)]
        public int? Stock { get; set; }

    }
}
