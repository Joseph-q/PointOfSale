using System.ComponentModel.DataAnnotations;

namespace PointOfSale.Roles.Controllers.DTOs.Request
{
    public record AddPermissionToRoleRequest
    {
        [Required]
        public required HashSet<int> permissionsIDs { get; init; }
    }
}
