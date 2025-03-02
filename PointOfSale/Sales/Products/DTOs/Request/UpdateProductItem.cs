using System.ComponentModel.DataAnnotations;

namespace PointOfSale.Sales.Products.DTOs.Request
{
    public record UpdateProductItem
    {
        [MaxLength(50)]
        public string? Barcode { get; set; }

        [MaxLength(50)]
        public string? Name { get; set; }

        [Range(0.01, double.MaxValue)]
        public double? Price { get; set; }

        [Range(1, int.MaxValue)]
        public int? Stock { get; set; }
    }
}
