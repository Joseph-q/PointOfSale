using Microsoft.AspNetCore.Mvc;
using PointOfSale.Sales.Products.Services;
using PointOfSale.Sales.Purchases.DTOs.Request;
using PointOfSale.Sales.Purchases.Services;

namespace PointOfSale.Sales.Purchases
{
    [Route("api/purchase")]
    public class PurchaseController(IPurchaseService purchaseService, IProductService productService) : ControllerBase
    {
        private readonly IPurchaseService _purchaseService = purchaseService;
        private readonly IProductService _productService = productService;


        [HttpPost]
        public async Task<IActionResult> RealicePurchase([FromBody] RealicePurchaseRequest purchaseRequests)
        {
            int rowsAffected = await _purchaseService.ProcessBulkPurchaseAsync(purchaseRequests);
            if (rowsAffected == 0)
            {
                return BadRequest("Some products do not exist or there was an error in the purchase.");
            }

            return Ok(new { rowsAffected });
        }
    }
}
