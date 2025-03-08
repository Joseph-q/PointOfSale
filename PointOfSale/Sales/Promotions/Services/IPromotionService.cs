using PointOfSale.Models;
using PointOfSale.Sales.Promotions.DTOs.Request;
using PointOfSale.Sales.Promotions.DTOs.Response;

namespace PointOfSale.Sales.Promotions.Services
{
    public interface IPromotionService
    {
        Task<PromotionResponse> GetPromotionResponseById();
        Task<Promotion> GetPromotionById();

        Task<List<PromotionResponse>> GetPromotionsResponse(GetPromotionsQueryParams queryParams);

        Task<List<Promotion>> GetPromotions(GetPromotionsQueryParams queryParams);

        Task CreatePromotion(Promotion promotion);

        Task UpdatePromotion(Promotion promotion);

        Task DeletePromotion(Promotion promotion);

    }
}
