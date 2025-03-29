using PointOfSale.Shared.Exeptions;
using System.Net;

namespace PointOfSale.Roles.Exceptions
{
    public class RoleNotFoundException : GlobalExceptionError
    {
        public RoleNotFoundException() : base(HttpStatusCode.NotFound, "Role not found")
        {
        }

        public RoleNotFoundException(string message) : base(HttpStatusCode.NotFound, message)
        {
        }
    }
}
