using PointOfSale.Shared.Exeptions;
using System.Net;

namespace PointOfSale.Roles.Exceptions
{
    public class RoleAlreadyExistException : GlobalExceptionError
    {
        public RoleAlreadyExistException(string message = "Role Already Exist", string? detail = null) : base(HttpStatusCode.BadRequest, message)
        {
        }
    }
}
