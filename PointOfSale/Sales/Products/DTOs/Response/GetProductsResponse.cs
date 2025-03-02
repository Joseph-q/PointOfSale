namespace PointOfSale.Sales.Products.DTOs.Response
{
    public record GetProductsResponse
    {
        public string Barcode { get; set; } = null!;
        public string Name { get; set; } = null!;
        public double Price { get; set; } = 0;
        public int Stock { get; set; } = 0;
    }
}
