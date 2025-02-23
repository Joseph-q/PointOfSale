using System.ComponentModel.DataAnnotations;

namespace PointOfSale.Roles.Controllers.DTOs.Request
{
    public class AddPermissionToRoleRequest
    {
        [Required]
        public required HashSet<int> permissionsIDs { get; set; }
    }
}
