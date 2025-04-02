using System.ComponentModel.DataAnnotations;

namespace PointOfSale.Identity.Users.Controllers.DTOs.Request
{
    public record CreateUserRequest
    {
        [Required()]
        [MaxLength(50)]
        [RegularExpression("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+")]
        public string Username { get; init; } = string.Empty;

        [EmailAddress()]
        public string? Email { get; init; }

        [Required()]
        [Range(1, int.MaxValue)]
        public int RoleId { get; init; }


        [Required]
        [MaxLength(60)]
        public string Password { get; init; } = string.Empty;

    }
}
