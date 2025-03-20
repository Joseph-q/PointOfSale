using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PointOfSale.Models;
using PointOfSale.Roles.Controllers.DTOs.Request;
using PointOfSale.Roles.Exceptions;

namespace PointOfSale.Roles.Services
{
    public class RoleService(SalesContext contex, IMapper mapper) : IRoleService
    {
        private readonly SalesContext _context = contex;
        private readonly IMapper _mapper = mapper;

        public async Task CreateRole(Role role)
        {
            _context.Add(role);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex) when (ex.InnerException is SqlException sqlEx && sqlEx.Number == 2627)
            {
                throw new RoleAlreadyExistException();
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }

        public Task<Role?> GetRoleById(int id)
        {
            return _context.Roles.FirstOrDefaultAsync(r => r.Id == id);
        }

        public Task<List<Role>> GetRoles(GetRolesQueryParams queryParams)
        {
            int page = queryParams.Page;
            int limit = queryParams.Limit;
            return _context.Roles.Skip((page - 1)).Take(limit)
                .OrderBy(r => r.Name)
                .ToListAsync();
        }

        public Task<int> UpdateRole(Role roleDb, UpdateRoleRequest roleToUpdate)
        {
            _mapper.Map(roleToUpdate, roleDb);

            try
            {
                return _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex) when (ex.InnerException is SqlException sqlEx && sqlEx.Number == 2627)
            {
                throw new RoleAlreadyExistException();
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }

        public Task<int> DeleteRole(Role roleDb)
        {
            _context.Remove(roleDb);

            return _context.SaveChangesAsync();
        }


        public async Task<int> AddPermissionsToRole(Role role, List<Permission> permissions)
        {


            foreach (var permission in permissions)
            {
                // Verifica si el rol ya tiene este permiso
                if (!role.Permissions.Contains(permission))
                {
                    role.Permissions.Add(permission);
                }
            }

            return await _context.SaveChangesAsync();
        }

        public Task<int> RemovePermissionsFromRole(Role role, List<Permission> permissions)
        {
            foreach (var permission in permissions)
            {
                role.Permissions.Remove(permission);
            }


            try
            {
                return _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex) when (ex.InnerException is SqlException sqlEx && sqlEx.Number == 2627)
            {
                throw new PermissionsExistsException();
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }

        public Task<Role?> GetRoleByIdWithPermissions(int id)
        {
            return _context.Roles
                                     .Include(r => r.Permissions)
                                     .FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}
