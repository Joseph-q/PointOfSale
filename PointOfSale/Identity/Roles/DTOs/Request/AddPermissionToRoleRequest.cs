using System.ComponentModel.DataAnnotations;

namespace PointOfSale.Identity.Roles.DTOs.Request
{
    public record AddPermissionToRoleRequest
    {
        [Required]
        public required HashSet<int> permissionsIDs { get; init; }
    }
}
