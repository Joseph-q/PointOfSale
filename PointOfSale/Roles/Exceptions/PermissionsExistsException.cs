using PointOfSale.Shared.Exeptions;
using System.Net;

namespace PointOfSale.Roles.Exceptions
{
    public class PermissionsExistsException : GlobalExceptionError
    {
        public PermissionsExistsException(string message = "Some permissions already exits", string? detail = null) : base(HttpStatusCode.BadRequest, message, detail)
        {
        }
    }
}
