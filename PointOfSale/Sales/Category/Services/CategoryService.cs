using Microsoft.EntityFrameworkCore;
using PointOfSale.Models;
using PointOfSale.Sales.Category.DTOs.Request;
using PointOfSale.Sales.Category.DTOs.Response;

namespace PointOfSale.Sales.Category.Services
{
    public class CategoryService(CorteDeCajaContext context) : ICategoryService
    {
        private readonly CorteDeCajaContext _context = context;

        public async Task AssignProductsToCategoryAsync(ProductCategory category, List<ProductsItem> productsToAssign)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category), "The category cannot be null.");

            if (productsToAssign == null || productsToAssign.Count == 0)
                throw new ArgumentException("At least one product must be provided for assignment.");

            foreach (var product in productsToAssign)
            {
                category.ProductsItems.Add(product);
            }

            // Save changes to the database
            await _context.SaveChangesAsync();
        }

        public Task CreateCategoryAsync(CreateUpdateCategoryRequest createUpdate)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCategoryAsync(ProductCategory category)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCategoryWithProductsAsync(ProductCategory category)
        {
            throw new NotImplementedException();
        }

        public Task<List<GetCategoryResponse>> GetCategoriesResponseAsync(GetCategoriesQueryParams queryParams)
        {
            throw new NotImplementedException();
        }

        public Task<ProductCategory?> GetCategoryByIdAsync(int id) => _context.ProductCategories.FirstOrDefaultAsync(c => c.Id.Equals(id));


        public Task<GetCategoryResponse?> GetCategoryResponseByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCategoryAsync(ProductCategory category)
        {
            throw new NotImplementedException();
        }
    }
}
