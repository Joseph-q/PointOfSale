using PointOfSale.Identity.Users.Controllers.DTOs.Request;
using PointOfSale.Models;

namespace PointOfSale.Identity.Users.Services
{
    public interface IUserService
    {

        Task CreateUser(CreateUserRequest user);
        Task<List<User>> GetUsers(GetUsersQueryParams queryParams);
        Task<User?> GetUserById(int id);
        Task<User?> GetUserById(int id, GetUserQueryParams queryParams);
        Task UpdateUser(User userDb, UpdateUserRequest userToUpdate);
        Task DeleteUser(User user);

    }
}
