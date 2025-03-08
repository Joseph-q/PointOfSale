using System.ComponentModel.DataAnnotations;

namespace PointOfSale.Sales.Promotions.DTOs.Request
{
    public class GetPromotionsQueryParams
    {
        [Required]
        public bool Active { get; set; } = true;
    }
}
