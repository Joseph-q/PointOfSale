using System.ComponentModel.DataAnnotations;

namespace PointOfSale.Auth.Controller.Request
{
    public record LoginRequestData
    {
        [Required]
        public required string Username { get; init; }
        [Required]
        public required string Password { get; init; }
    }
}
