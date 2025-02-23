using PointOfSale.Shared.Exeptions;
using System.Net;

namespace PointOfSale.Roles.Exceptions
{
    public class RoleNotFoundException : GlobalExceptionError
    {
        public RoleNotFoundException(string? message = null) : base(HttpStatusCode.NotFound, message ?? "Role not found")
        {
        }
    }
}
