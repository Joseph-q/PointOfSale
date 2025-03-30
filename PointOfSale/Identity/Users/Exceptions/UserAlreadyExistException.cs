using PointOfSale.Shared.Exeptions;
using System.Net;

namespace PointOfSale.Identity.Users.Exceptions
{
    public class UserAlreadyExistException : GlobalExceptionError
    {
        public UserAlreadyExistException() : base(HttpStatusCode.BadRequest, "User Already Exist")
        {
        }

        public UserAlreadyExistException(string message) : base(HttpStatusCode.BadRequest, message)
        {
        }

    }
}
