using PointOfSale.Shared.Exeptions;
using System.Net;

namespace PointOfSale.Users.Exeptions
{
    public class UserNotFoundException : GlobalExceptionError
    {
        public UserNotFoundException(string? message) : base(HttpStatusCode.NotFound, message ?? "User not found")
        {
        }
    }

}
