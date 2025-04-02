namespace PointOfSale.Sales.Category.DTOs.Response
{
    public record GetCategoryResponse
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
    }
}
