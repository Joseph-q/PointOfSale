using PointOfSale.Models;
using PointOfSale.Sales.Products.DTOs.Request;

namespace PointOfSale.Sales.Products.Services
{
    public interface IProductService
    {
        Task<List<ProductsItem>> GetProductItemsAsync(GetProductsQueryParams queryParams);
        Task<ProductsItem?> GetProductItemByBarCodeAsync(string barcode);
        Task<int> CreateProductItemAsync(CreateProductItem product);
        Task<int> UpdateProductItemAsync(ProductsItem product);

        Task<int> DeleteProductItemAsync(ProductsItem product);
    }
}
