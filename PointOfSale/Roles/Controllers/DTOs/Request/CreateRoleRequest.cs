using System.ComponentModel.DataAnnotations;

namespace PointOfSale.Roles.Controllers.DTOs.Request
{
    public class CreateRoleRequest
    {
        [Required]
        [MaxLength(20)]
        public required string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public required string Description { get; set; }
    }

}
