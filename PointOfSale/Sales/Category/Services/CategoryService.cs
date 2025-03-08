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

        public Task CreateCategoryAsync(ProductCategory createUpdate)
        {
            _context.Add(createUpdate);
            return _context.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(ProductCategory category)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                await _context.ProductsItems
                      .Where(p => p.CategoryId == category.Id)
                      .ExecuteUpdateAsync(p => p.SetProperty(x => x.CategoryId, (int?)null));


                _context.ProductCategories.Remove(category);

                await _context.SaveChangesAsync();

                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
            finally
            {
                transaction.Dispose();
            }
        }

        public async Task DeleteCategoryWithProductsAsync(ProductCategory category)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                await _context.ProductsItems
                      .Where(p => p.CategoryId == category.Id)
                      .ExecuteDeleteAsync();


                _context.ProductCategories.Remove(category);

                await _context.SaveChangesAsync();

                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
            finally
            {
                transaction.Dispose();
            }

        }

        public Task<List<GetCategoryResponse>> GetCategoriesResponseAsync(GetCategoriesQueryParams queryParams)
        {
            var chain = _context.ProductCategories.AsQueryable();

            int limit = queryParams.Limit;
            int page = queryParams.Page;
            string attributeToOrder = queryParams.OrderBy;
            string? orderDirection = queryParams.OrderDirection;

            if (!string.IsNullOrEmpty(attributeToOrder))
            {
                bool descending = orderDirection?.ToLower() == "desc";
                chain = descending
                    ? chain.OrderByDescending(c => EF.Property<object>(c, attributeToOrder))
                    : chain.OrderBy(c => EF.Property<object>(c, attributeToOrder));
            }

            int skip = (page - 1) * limit;
            chain = chain.Skip(skip).Take(limit);

            return chain.Select(c => new GetCategoryResponse
            {
                Id = c.Id,
                Name = c.Name,
            }).ToListAsync();
        }

        public Task<ProductCategory?> GetCategoryByIdAsync(int id) => _context.ProductCategories.FirstOrDefaultAsync(c => c.Id.Equals(id));


        public Task<GetCategoryResponse?> GetCategoryResponseByIdAsync(int id)
        {
            return _context.ProductCategories
                .Where(p => p.Id.Equals(id))
                .Select(c => new GetCategoryResponse { Id = c.Id, Name = c.Name })
                .FirstOrDefaultAsync();
        }

        public Task UpdateCategoryAsync(ProductCategory category)
        {
            _context.Update(category);
            return _context.SaveChangesAsync();
        }
    }
}
