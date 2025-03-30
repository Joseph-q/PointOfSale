using PointOfSale.Shared.Exeptions;
using System.Net;

namespace PointOfSale.Identity.Roles.Exceptions
{
    public class RoleAlreadyExistException : GlobalExceptionError
    {
        public RoleAlreadyExistException(string message = "Role Already Exist", string? detail = null) : base(HttpStatusCode.BadRequest, message)
        {
        }
    }
}
