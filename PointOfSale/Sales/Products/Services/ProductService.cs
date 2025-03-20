using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PointOfSale.Models;
using PointOfSale.Sales.Products.DTOs.Request;
using PointOfSale.Sales.Products.DTOs.Response;

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

        public Task<GetProductItemResponse?> GetProductItemResponseByBarCodeAsync(string barcode)
        {
            return _context.ProductsItems.Select(p => new GetProductItemResponse
            {
                Barcode = p.Barcode,
                Name = p.Name,
                Price = p.Price,
                Stock = p.Stock,
                Sold = p.Sold,
                CategoryId = p.CategoryId,
                SupplierId = p.SupplierId,
                DateAdded = p.DateAdded,
                ExpiredDate = p.DateAdded
            }).FirstOrDefaultAsync(p => p.Barcode.Equals(barcode));
        }

        public Task<List<ProductsItem>> GetProductsItemsByIDsAsync(string[] productsBarcode) => _context.ProductsItems.Where(p => productsBarcode.Contains(p.Barcode)).ToListAsync();
        public Task<List<ProductsItem>> GetProductsItemsByIDsAsync(string[] productsBarcode, CancellationToken cancellationToken) => _context.ProductsItems.Where(p => productsBarcode.Contains(p.Barcode)).ToListAsync(cancellationToken);


        public Task<List<GetProductsResponse>> GetResponseProductItemsAsync(GetProductsQueryParams queryParams)
        {
            var chain = _context.ProductsItems.AsQueryable();

            if (queryParams != null)
            {
                if (queryParams.CategoryId != null && queryParams.CategoryId > 0)
                {
                    chain = chain.Where(p => p.Category.Id.Equals(queryParams.CategoryId));
                }

                if (queryParams.Price != null)
                {
                    chain = chain.Where(p => p.Price.Equals(queryParams.Price));
                }

                if (queryParams.SupplierId != null && queryParams.SupplierId > 0)
                {
                    chain = chain.Where(p => p.SupplierId.Equals(queryParams.SupplierId));
                }

                if (queryParams.PurchaseId != null && queryParams.PurchaseId > 0)
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

            return chain.Select(p => new GetProductsResponse { Barcode = p.Barcode, Price = p.Price, Name = p.Name, Stock = p.Stock ?? 0 }).ToListAsync();
        }

        public Task<int> UpdateProductItemAsync(ProductsItem product)
        {
            _context.Update(product);

            return _context.SaveChangesAsync();
        }
    }
}
