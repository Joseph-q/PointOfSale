using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PointOfSale.Models;
using PointOfSale.Sales.Products.DTOs.Request;

namespace PointOfSale.Sales.Products.Services
{
    public class ProductService(CorteDeCajaContext context, IMapper _mapper) : IProductService
    {
        private readonly CorteDeCajaContext _context = context;

        public Task<int> CreateProductItemAsync(CreateProductItem product)
        {
            ProductsItem p = _mapper.Map<ProductsItem>(product);

            _context.Add(p);

            return _context.SaveChangesAsync();
        }

        public Task<int> DeleteProductItemAsync(ProductsItem product)
        {
            _context.Remove(product);

            return _context.SaveChangesAsync();
        }

        public Task<ProductsItem?> GetProductItemByBarCodeAsync(string barcode)
        {
            return _context.ProductsItems.FirstOrDefaultAsync(p => p.Barcode.Equals(barcode));
        }

        public Task<List<ProductsItem>> GetProductItemsAsync(GetProductsQueryParams queryParams)
        {
            var chain = _context.ProductsItems.AsQueryable();

            if (queryParams != null)
            {
                if (!string.IsNullOrEmpty(queryParams.Category))
                {
                    chain = chain.Where(p => p.Category.Id.Equals(queryParams.Category));
                }

                if (!string.IsNullOrEmpty(queryParams.Price))
                {
                    chain = chain.Where(p => p.Price.Equals(queryParams.Price));
                }

                if (!string.IsNullOrEmpty(queryParams.Supplier))
                {
                    chain = chain.Where(p => p.SupplierId.Equals(queryParams.Supplier));
                }

                if (!string.IsNullOrEmpty(queryParams.Purchase))
                {

                    // TODO: this function is not implemented
                    // You have to find the products that have sell in the purchase
                    //chain = chain.Where(p => p.PurchaseDetails.Equals(queryParams.Purchase));
                }

                if (!string.IsNullOrEmpty(queryParams.OrderBy))
                {
                    if (queryParams.OrderDirection == "asc")
                    {
                        chain = chain.OrderBy(p => p.GetType().GetProperty(queryParams.OrderBy));
                    }
                    else
                    {
                        chain = chain.OrderByDescending(p => p.GetType().GetProperty(queryParams.OrderBy));
                    }
                }

                if (queryParams.Page.HasValue && queryParams.Limit.HasValue)
                {
                    chain = chain.Skip((queryParams.Page.Value - 1) * queryParams.Limit.Value).Take(queryParams.Limit.Value);
                }
            }

            return chain.ToListAsync();
        }

        public Task<int> UpdateProductItemAsync(ProductsItem product)
        {
            _context.Update(product);

            return _context.SaveChangesAsync();
        }
    }
}
