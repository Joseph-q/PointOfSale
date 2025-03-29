using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PointOfSale.Models;
using PointOfSale.Sales.Purchases.DTOs.Request;
using PointOfSale.Shared.Exeptions;

namespace PointOfSale.Sales.Purchases.Services
{
    public class PurchaseService(SalesContext context, IMapper mapper) : IPurchaseService
    {
        private readonly SalesContext _context = context;
        private readonly IMapper _mapper = mapper;


        public async Task<int> ProcessBulkPurchaseAsync(RealicePurchaseRequest purchaseRequest)
        {
            List<ProductToSaleRequest> productsToSell = purchaseRequest.Purchase;
            HashSet<string> productBarcodes = productsToSell.Select(p => p.ProductBarcode).ToHashSet();

            bool allProductsExist = await DoAllProductsExistAsync(productBarcodes);
            if (!allProductsExist)
            {
                throw new NotFoundException("One or more products do not exist in the inventory.");
            }

            await using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var purchaseDetails = _mapper.Map<List<PurchaseDetail>>(productsToSell);
                await _context.PurchaseDetails.AddRangeAsync(purchaseDetails);

                var purchase = new Purchase
                {
                    UserId = 1, // Considera recibir el UserId en la request en lugar de hardcodearlo
                    PurchaseDetails = purchaseDetails
                };
                await _context.Purchases.AddAsync(purchase);

                int result = await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return result;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                Console.WriteLine($"Error in ProcessBulkPurchaseAsync: {ex.Message}");
                throw;
            }
        }

        private async Task<bool> DoAllProductsExistAsync(HashSet<string> productBarcodes)
        {
            int existingProductsCount = await _context.ProductsItems
                .Where(p => productBarcodes.Contains(p.Barcode))
                .CountAsync();

            return existingProductsCount == productBarcodes.Count;
        }
    }
}
