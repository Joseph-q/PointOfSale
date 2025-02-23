using Microsoft.AspNetCore.Mvc;
using PointOfSale.Auth.Controller.Request;
using PointOfSale.Auth.Services;
using PointOfSale.Models;
using PointOfSale.Shared.DTOs.Responses;

namespace PointOfSale.Auth.Controller
{
    [ApiController]
    [Route("api/auth")]
    [Produces("application/json")]
    [ProducesResponseType(401)]
    [ProducesResponseType(404, Type = typeof(ErrorResponseDto))]
    public class AuthController(AuthService authservice) : ControllerBase
    {
        private readonly AuthService _authservice = authservice;

        [ProducesResponseType(200, Type = typeof(string))]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestData login)
        {
            User? user = await _authservice.Login(login);

            if (user == null)
            {
                return Unauthorized();
            }

            string token = _authservice.GenerateJwtToken(user);

            return Ok(token);
        }
    }
}
