using System.ComponentModel.DataAnnotations;

namespace PointOfSale.Auth.Controller.Request
{
    public class LoginRequestData
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
