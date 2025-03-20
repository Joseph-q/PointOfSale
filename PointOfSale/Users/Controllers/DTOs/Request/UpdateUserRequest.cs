using System.ComponentModel.DataAnnotations;

namespace PointOfSale.Users.Controllers.DTOs.Request
{
    public record UpdateUserRequest
    {
        [StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres")]
        public string? Username { get; init; }

        [StringLength(60, MinimumLength = 5, ErrorMessage = "La contraseña debe tener al menos 5 caracteres")]
        public string? Password { get; init; }

        [Range(1, int.MaxValue, ErrorMessage = "Rol no valido")]
        public int? RoleId { get; init; }
    }
}
