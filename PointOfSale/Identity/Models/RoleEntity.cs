using Microsoft.AspNetCore.Identity;

namespace PointOfSale.Identity.Models
{
    public class RoleEntity : IdentityRole
    {
        public string? Description { get; set; }

        public virtual ICollection<PermissionEntity> Permissions { get; set; } = new List<PermissionEntity>();

        public RoleEntity(string name, string? description = null)
            : base(name)
        {
            Description = description;
            NormalizedName = name.ToUpperInvariant();
        }
    }
}
