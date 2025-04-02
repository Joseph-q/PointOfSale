namespace PointOfSale.Identity.Models
{
    public partial class PermissionEntity
    {
        public int Id { get; set; }

        public string Action { get; set; } = null!;

        public string Subject { get; set; } = null!;

        public string? Condition { get; set; }

        public bool? Inverted { get; set; }

        public virtual ICollection<RoleEntity> Roles { get; set; } = new List<RoleEntity>();
    }
}
