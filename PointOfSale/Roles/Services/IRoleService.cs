using PointOfSale.Models;
using PointOfSale.Roles.Controllers.DTOs.Request;

namespace PointOfSale.Roles.Services
{
    public interface IRoleService
    {
        Task CreateRole(Role role);
        Task<Role?> GetRoleById(int id);
        Task<Role?> GetRoleByIdWithPermissions(int id);
        Task<List<Role>> GetRoles(GetRolesQueryParams queryParams);
        Task<int> UpdateRole(Role roleDb, UpdateRoleRequest roleToUpdate);
        Task<int> DeleteRole(Role roleDb);
        Task<int> AddPermissionsToRole(Role role, List<Permission> permissionsIds);
        Task<int> RemovePermissionsFromRole(Role role, List<Permission> permissionsIds);

    }
}
