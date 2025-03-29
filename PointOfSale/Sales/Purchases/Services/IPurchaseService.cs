using PointOfSale.Sales.Purchases.DTOs.Request;

namespace PointOfSale.Sales.Purchases.Services
{
    public interface IPurchaseService
    {
        Task<int> ProcessBulkPurchaseAsync(RealicePurchaseRequest purchaseRequests);
    }
}
