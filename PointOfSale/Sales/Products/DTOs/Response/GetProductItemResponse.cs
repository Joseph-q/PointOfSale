namespace PointOfSale.Sales.Products.DTOs.Response
{
    public class GetProductItemResponse
    {
        public string Barcode { get; set; } = null!;

        public string Name { get; set; } = null!;

        public required double Price { get; set; }

        public int Stock { get; set; } = 0;

        public int Sold { get; set; } = 0;

        public string? Category { get; set; } = "No category";

        public string? Supplier { get; set; } = "No supplier";

        public DateOnly? ExpiredDate { get; set; }

        public DateOnly DateAdded { get; set; }

    }
}
