using PointOfSale.Models;
using PointOfSale.Sales.Products.DTOs.Request;
using PointOfSale.Sales.Products.DTOs.Response;

namespace PointOfSale.Sales.Products.Services
{
    public interface IProductService
    {
        Task<List<GetProductsResponse>> GetResponseProductItemsAsync(GetProductsQueryParams queryParams);


        Task<List<ProductsItem>> GetProductsItemsByIDsAsync(string[] barcodes);

        Task<ProductsItem?> GetProductItemByBarCodeAsync(string barcode);

        Task<GetProductItemResponse?> GetProductItemResponseByBarCodeAsync(string barcode);

        Task<int> CreateProductItemAsync(CreateProductItem product);
        Task<int> UpdateProductItemAsync(ProductsItem product);

        Task<int> DeleteProductItemAsync(ProductsItem product);
    }
}
