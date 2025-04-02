using PointOfSale.Shared.Exeptions;
using System.Net;

namespace PointOfSale.Identity.Users.Exceptions
{
    public class UserNotFoundException : GlobalExceptionError
    {
        public UserNotFoundException(string message) : base(HttpStatusCode.NotFound, message)
        {
        }

        public UserNotFoundException() : base(HttpStatusCode.NotFound, "User not found")
        {
        }
    }

}
