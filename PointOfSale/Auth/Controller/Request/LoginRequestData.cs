using System.ComponentModel.DataAnnotations;

namespace PointOfSale.Auth.Controller.Request
{
    public class LoginRequestData
    {
        [Required]
        public required string Username { get; set; }
        [Required]
        public required string Password { get; set; }
    }
}
