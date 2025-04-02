using PointOfSale.Identity.Users.Controllers.DTOs.Request;
using PointOfSale.Identity.Users.Controllers.DTOs.Responses;
using PointOfSale.Identity.Users.DTOs.Responses;
using PointOfSale.Models;
using System.Linq.Expressions;

namespace PointOfSale.Identity.Users.Services
{
    public interface IUserService
    {
        // Read
        Task<bool> ExistsWithUsernameAndRoleAsync(string username, int roleId);
        Task<bool> ExistsWithEmailAsync(string email, int? exceptId = null);
        Task<List<User>> GetListByQueryParamsAsync(GetListUserQueryParams queryParams);
        Task<int> CountAllAsync(CancellationToken cancellationToken);


        //Responses
        Task<T> SelectByIdAsync<T>(int id, Expression<Func<User, T>> select);
        Task<List<UserDetailResponse>> GetListResponseByQueryParamsAsync(GetListUserQueryParams queryParams);

        // Modify
        Task<int> RegisterAsync(CreateUserRequest user);
        Task<int> UpdateAsync(int userId, UpdateUserRequest userToUpdate);
        Task<int> DeleteAsync(int userId);

        ////Permisions
        Task<UserPermissionResponse> GetPermissionsAsync(string userId);
        //Task<bool> HasPermissionsAsync(string userId);
        ////Roles
        //Task<RoleResponse> GetRolesAsync(string userId);


    }
}
