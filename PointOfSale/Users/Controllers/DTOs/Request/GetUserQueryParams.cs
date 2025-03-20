using System.ComponentModel.DataAnnotations;

namespace PointOfSale.Users.Controllers.DTOs.Request
{
    public record GetUserQueryParams
    {
        [Range(1, int.MaxValue, ErrorMessage = "El límite debe ser mayor o igual a 1.")]
        public int? RoleLimit { get; init; }
    }
}
