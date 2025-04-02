using Microsoft.AspNetCore.Identity;

namespace PointOfSale.Identity.Models
{
    public class UserEntity : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool IsActive { get; set; }
    }
}
