namespace PointOfSale.Sales.Products.DTOs.Response
{
    public class GetProductItemResponse
    {
        public string Barcode { get; set; } = null!;

        public string Name { get; set; } = null!;

        public double? Price { get; set; } = 0;

        public int? Stock { get; set; } = 0;

        public int? Sold { get; set; } = 0;

        public int? CategoryId { get; set; }

        public int? SupplierId { get; set; }

        public DateOnly? ExpiredDate { get; set; }

        public DateOnly? DateAdded { get; set; }


    }
}
