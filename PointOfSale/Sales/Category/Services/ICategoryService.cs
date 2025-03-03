using PointOfSale.Models;
using PointOfSale.Sales.Category.DTOs.Request;
using PointOfSale.Sales.Category.DTOs.Response;

namespace PointOfSale.Sales.Category.Services
{
    public interface ICategoryService
    {
        Task<GetCategoryResponse?> GetCategoryResponseByIdAsync(int id);

        Task<ProductCategory?> GetCategoryByIdAsync(int id);

        Task<List<GetCategoryResponse>> GetCategoriesResponseAsync(GetCategoriesQueryParams queryParams);

        Task CreateCategoryAsync(CreateUpdateCategoryRequest createUpdate);

        Task UpdateCategoryAsync(ProductCategory category);

        Task AssignProductsToCategoryAsync(ProductCategory category, List<ProductsItem> productsToAssign);

        Task DeleteCategoryWithProductsAsync(ProductCategory category);

        Task DeleteCategoryAsync(ProductCategory category);
    }
}
