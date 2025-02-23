using PointOfSale.Shared.Exeptions;
using System.Net;

namespace PointOfSale.Users.Exeptions
{
    public class UserAlreadyExistException : GlobalExceptionError
    {
        public UserAlreadyExistException(string? message = null, string? detail = null) : base(HttpStatusCode.BadRequest, message ?? "User Already Exist", detail)
        {
        }
    }
}
