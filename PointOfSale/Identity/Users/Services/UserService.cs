using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PointOfSale.Identity.Users.Controllers.DTOs.Request;
using PointOfSale.Identity.Users.Controllers.DTOs.Responses;
using PointOfSale.Identity.Users.Exceptions;
using PointOfSale.Models;
using System.Linq.Expressions;


namespace PointOfSale.Identity.Users.Services;

internal sealed partial class UserService(
    SalesContext context,
    UserManager<User> userManager,
    IMapper mapper) : IUserService
{
    public Task<bool> ExistsWithUsernameAndRoleAsync(string username, int roleId)
    {
        return context.Users.Where(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && u.Roles.Any(r => r.Id.Equals(roleId))).AnyAsync();
    }

    public Task<bool> ExistsWithEmailAsync(string email, int? exceptId = null)
    {
        return context.Users.Where(u => u.Username.Equals(email, StringComparison.OrdinalIgnoreCase) && u.Id != exceptId).AnyAsync();
    }

    public Task<List<User>> GetListByQueryParamsAsync(GetListUserQueryParams queryParams)
    {
        int page = queryParams.Page;
        int limit = queryParams.Limit;
        int? roleId = queryParams.RoleId;


        var chain = context.Users.AsQueryable()
            .Select(u => new User
            {
                Id = u.Id,
                Username = u.Username,
                CreatedAt = u.CreatedAt,
            });

        if (roleId != null && roleId > 0)
        {
            chain = chain.Where(u => u.Roles.Any(role => role.Id == queryParams.RoleId));
        }

        return chain.Skip((page - 1) * limit).Take(limit)
            .OrderBy(u => u.CreatedAt)
            .ToListAsync();
    }

    public Task<int> CountAllAsync(CancellationToken cancellationToken)
    {

        return context.Users.AsNoTracking().CountAsync(cancellationToken);
    }

    public async Task<T> SelectByIdAsync<T>(int id, Expression<Func<User, T>> select)
    {
        T user = await context.Users
         .AsNoTracking()
         .Where(u => u.Id == id)
         .Select(select)
         .FirstOrDefaultAsync() ?? throw new UserNotFoundException();

        return user;
    }
    public Task<List<UserDetailResponse>> GetListResponseByQueryParamsAsync(GetListUserQueryParams queryParams)
    {
        int page = queryParams.Page;
        int limit = queryParams.Limit;
        int? roleId = queryParams.RoleId;


        var chain = context.Users.AsQueryable()
            .Select(u => new User
            {
                Id = u.Id,
                Username = u.Username,
                CreatedAt = u.CreatedAt,
            });

        if (roleId != null && roleId > 0)
        {
            chain = chain.Where(u => u.Roles.Any(role => role.Id == queryParams.RoleId));
        }

        return chain.Skip((page - 1) * limit).Take(limit)
            .OrderBy(u => u.CreatedAt)
            .Select(u => new UserDetailResponse { Username = u.Username, CreatedAt = u.CreatedAt, Id = u.Id })
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<int> RegisterAsync(CreateUserRequest user)
    {
        _ = ExistsWithUsernameAndRoleAsync(user.Username, user.RoleId) ?? throw new UserAlreadyExistException("User already exist with same rol and username");

        if (user.Email is not null) _ = ExistsWithEmailAsync(user.Email) ?? throw new UserAlreadyExistException("User already exist whit that email");

        User userToCreate = mapper.Map<User>(user);

        userToCreate.Roles.Add(new Role { Id = user.RoleId });

        context.Add(userToCreate);

        return await context.SaveChangesAsync();
    }

    public async Task<int> UpdateAsync(int userId, UpdateUserRequest userToUpdate)
    {
        User user = await context.Users.Where(u => u.Id.Equals(userId)).FirstOrDefaultAsync() ?? throw new UserNotFoundException();

        user = mapper.Map<User>(userToUpdate);

        context.Update(user);


        return await context.SaveChangesAsync();
    }

    public async Task<int> DeleteAsync(int userId)
    {
        User user = await context.Users.Where(u => u.Id.Equals(userId)).Select(u => new User { Id = u.Id }).FirstOrDefaultAsync() ?? throw new UserNotFoundException();

        context.Remove(user);

        return await context.SaveChangesAsync();

    }

}

