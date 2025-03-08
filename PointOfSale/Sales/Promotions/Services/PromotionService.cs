using PointOfSale.Models;
using PointOfSale.Sales.Promotions.DTOs.Request;
using PointOfSale.Sales.Promotions.DTOs.Response;

namespace PointOfSale.Sales.Promotions.Services
{
    public class PromotionService : IPromotionService
    {
        public Task CreatePromotion(Promotion promotion)
        {
            throw new NotImplementedException();
        }

        public Task DeletePromotion(Promotion promotion)
        {
            throw new NotImplementedException();
        }

        public Task<Promotion> GetPromotionById()
        {
            throw new NotImplementedException();
        }

        public Task<PromotionResponse> GetPromotionResponseById()
        {
            throw new NotImplementedException();
        }

        public Task<List<Promotion>> GetPromotions(GetPromotionsQueryParams queryParams)
        {
            throw new NotImplementedException();
        }

        public Task<List<PromotionResponse>> GetPromotionsResponse(GetPromotionsQueryParams queryParams)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePromotion(Promotion promotion)
        {
            throw new NotImplementedException();
        }
    }
}
