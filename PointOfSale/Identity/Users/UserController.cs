using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PointOfSale.Auth.Atributtes;
using PointOfSale.Auth.Constants;
using PointOfSale.Identity.Users.Controllers.DTOs.Request;
using PointOfSale.Identity.Users.Controllers.DTOs.Responses;
using PointOfSale.Identity.Users.DTOs.Responses;
using PointOfSale.Identity.Users.Services;
using PointOfSale.Shared.DTOs.Responses;

namespace PointOfSale.Identity.Users
{

    [Authorize]
    [PermissionAuthorize]
    [ApiController]
    [Route("api/user")]
    [Produces("application/json")]
    [ProducesResponseType(401)]
    [ProducesResponseType(404, Type = typeof(ErrorResponseDto))]
    public class UserController(IUserService userService) : ControllerBase
    {

        [ProducesResponseType(201)]
        [HttpPost("register")]
        [PermissionPolicy(DefaultActions.Create, DefaultSubjects.Users)]
        public async Task<IActionResult> RegisterUser([FromBody] CreateUserRequest user)
        {
            await userService.RegisterAsync(user);
            return Created();
        }


        [HttpGet]
        [PermissionPolicy(DefaultActions.Read, DefaultSubjects.Users)]
        public async Task<IActionResult> GetUsers([FromQuery] GetListUserQueryParams queryParams)
        {
            List<UserDetailResponse> users = await userService.GetListResponseByQueryParamsAsync(queryParams);

            return Ok(users);
        }

        [HttpGet("{id}")]
        [PermissionPolicy(DefaultActions.Read, DefaultSubjects.Users)]
        public async Task<IActionResult> GetUser(int id)
        {
            UserDetailResponse user = await userService.SelectByIdAsync(id,
                u => new UserDetailResponse
                {
                    Id = u.Id,
                    Username = u.Username,
                    CreatedAt = u.CreatedAt
                });

            return Ok(user);
        }


        [HttpPut("{id}")]
        [PermissionPolicy(DefaultActions.Update, DefaultSubjects.Users)]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserRequest userToUpdate)
        {
            await userService.UpdateAsync(id, userToUpdate);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [PermissionPolicy(DefaultActions.Delete, DefaultSubjects.Users)]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await userService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{userId}/permissions")]
        [PermissionPolicy(DefaultActions.Read, DefaultSubjects.Permissions)]
        public async Task<IActionResult> GetPermissions(string userId)
        {
            UserPermissionResponse userPermissions = await userService.GetPermissionsAsync(userId);

            return Ok(userPermissions);
        }


    }

}
