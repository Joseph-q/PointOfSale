namespace PointOfSale.Sales.Products.DTOs.Response
{
    public record GetProductsResponse
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Supplier { get; set; }
        public string Purchase { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
