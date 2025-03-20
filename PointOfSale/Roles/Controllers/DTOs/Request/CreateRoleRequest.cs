using System.ComponentModel.DataAnnotations;

namespace PointOfSale.Roles.Controllers.DTOs.Request
{
    public record CreateRoleRequest
    {
        [Required]
        [MaxLength(20)]
        public required string Name { get; init; }

        [Required]
        [MaxLength(50)]
        public required string Description { get; init; }
    }

}
