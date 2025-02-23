using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PointOfSale.Auth.Atributtes;
using PointOfSale.Auth.Constants;
using PointOfSale.Models;
using PointOfSale.Permissions;
using PointOfSale.Roles.Controllers.DTOs.Request;
using PointOfSale.Roles.Controllers.DTOs.Response;
using PointOfSale.Roles.Services;
using PointOfSale.Shared.DTOs.Responses;

namespace PointOfSale.Roles.Controllers
{
    [ApiController]
    [Route("api/roles")]
    [Produces("application/json")]
    [ProducesResponseType(401)]
    [ProducesResponseType(404, Type = typeof(ErrorResponseDto))]
    public class RoleController(IRoleService roleService, IMapper mapper, IPermissionService permissionService) : ControllerBase
    {
        private readonly IRoleService _roleService = roleService;
        private readonly IMapper _mapper = mapper;
        private readonly IPermissionService _permissionService = permissionService;

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(SuccessResponseDto<List<RoleDto>>))]
        [PermissionPolicy(DefaultActions.Read, DefaultSubjects.Roles)]
        public async Task<IActionResult> GetRoles([FromQuery] GetRolesQueryParams queryParams)
        {
            List<Role> roles = await _roleService.GetRoles(queryParams);

            var data = _mapper.Map<List<RoleDto>>(roles);

            SuccessResponseDto response = new() { Data = data };

            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(SuccessResponseDto<RoleDto>))]
        [PermissionPolicy(DefaultActions.Read, DefaultSubjects.Roles)]
        public async Task<IActionResult> GetRole(int id)
        {
            Role? role = await _roleService.GetRoleById(id);
            IResponse response;

            if (role == null)
            {
                response = new ErrorResponseDto { Title = "Role Not Found" };

                return NotFound(response);
            }

            var data = _mapper.Map<RoleDto>(role);
            response = new SuccessResponseDto { Data = data };

            return Ok(response);
        }


        [ProducesResponseType(201)]
        [HttpPost]
        [PermissionPolicy(DefaultActions.Create, DefaultSubjects.Roles)]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleRequest roleToCreate)
        {
            Role role = _mapper.Map<Role>(roleToCreate);

            await _roleService.CreateRole(role);

            return Created();
        }

        [ProducesResponseType(201, Type = typeof(SuccessResponseDto<RowsAffectedDTO>))]
        [HttpPut("{id}")]
        [PermissionPolicy(DefaultActions.Update, DefaultSubjects.Roles)]
        public async Task<IActionResult> UpdateRole(int id, [FromBody] UpdateRoleRequest roleToUpdate)
        {
            Role? role = await _roleService.GetRoleById(id);
            IResponse response;


            if (role == null)
            {
                response = new ErrorResponseDto { Title = "Role Not Found" };

                return NotFound(response);
            }

            int affectedRows = await _roleService.UpdateRole(role, roleToUpdate);

            response = new SuccessResponseDto
            {
                Data = new { affectedRows }
            };


            return Ok(response);
        }

        [ProducesResponseType(201, Type = typeof(SuccessResponseDto<RowsAffectedDTO>))]
        [HttpDelete("{id}")]
        [PermissionPolicy(DefaultActions.Delete, DefaultSubjects.Roles)]
        public async Task<IActionResult> DeleteRole(int id)
        {
            Role? role = await _roleService.GetRoleById(id);
            IResponse response;


            if (role == null)
            {
                response = new ErrorResponseDto { Title = "Role Not Found" };

                return NotFound(response);
            }

            int affectedRows = await _roleService.DeleteRole(role);

            response = new SuccessResponseDto
            {
                Data = new { affectedRows }
            };


            return Ok(response);
        }

        [HttpPost("{id}/permissions")]
        [ProducesResponseType(200, Type = typeof(SuccessResponseDto<RowsAffectedDTO>))]
        [PermissionPolicy(DefaultActions.Update, DefaultSubjects.Roles)]
        public async Task<IActionResult> AddPermissions(int id, [FromBody] AddPermissionToRoleRequest permissionRequest)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = cancellationTokenSource.Token;

            Role? role = await _roleService.GetRoleByIdWithPermissions(id);
            Task<List<Permission>> permissionsTask = _permissionService.FindPermitionByIds(permissionRequest.permissionsIDs, cancellationToken);

            IResponse response;
            if (role == null)
            {
                cancellationTokenSource.Cancel();
                response = new ErrorResponseDto { Title = "Role Not Found" };
                return NotFound(response);
            }

            List<Permission> permissions = await permissionsTask;

            if (permissions.Count == 0)
            {
                response = new ErrorResponseDto { Title = "Permissions Not Found" };
                return NotFound(response);
            }

            if (permissions.Count != permissionRequest.permissionsIDs.Count)
            {
                response = new ErrorResponseDto { Title = "Some Permissions Not Found" };
                return NotFound(response);
            }

            int affectedRows = await _roleService.AddPermissionsToRole(role, permissions);

            response = new SuccessResponseDto
            {
                Data = new { affectedRows }
            };
            return Ok(response);
        }

        [HttpDelete("{id}/permissions")]
        [ProducesResponseType(200, Type = typeof(SuccessResponseDto<RowsAffectedDTO>))]
        [PermissionPolicy(DefaultActions.Update, DefaultSubjects.Roles)]
        public async Task<IActionResult> DeletePermissions(int id, [FromBody] AddPermissionToRoleRequest permissionRequest)
        {
            var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;

            Role? role = await _roleService.GetRoleByIdWithPermissions(id);
            Task<List<Permission>> permissionsTask = _permissionService.FindPermitionByIds(permissionRequest.permissionsIDs, cancellationToken);

            IResponse response;
            if (role == null)
            {
                cancellationTokenSource.Cancel();
                response = new ErrorResponseDto { Title = "Role Not Found" };
                return NotFound(response);
            }

            List<Permission> permissions = await permissionsTask;

            if (permissions.Count == 0)
            {
                response = new ErrorResponseDto { Title = "Permissions Not Found" };
                return NotFound(response);
            }

            if (permissions.Count != permissionRequest.permissionsIDs.Count)
            {
                response = new ErrorResponseDto { Title = "Some Permissions Not Found" };
                return NotFound(response);
            }

            int affectedRows = await _roleService.RemovePermissionsFromRole(role, permissions);

            response = new SuccessResponseDto
            {
                Data = new { affectedRows }
            };
            return Ok(response);

        }

    }
}
