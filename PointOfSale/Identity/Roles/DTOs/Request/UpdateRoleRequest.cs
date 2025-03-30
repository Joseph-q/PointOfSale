using System.ComponentModel.DataAnnotations;

namespace PointOfSale.Identity.Roles.DTOs.Request
{
    public record UpdateRoleRequest
    {
        [MaxLength(20)]
        public string? Name { get; init; }

        [MaxLength(50)]
        public string? Description { get; init; }
    }
}
