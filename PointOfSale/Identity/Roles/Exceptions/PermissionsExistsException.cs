using PointOfSale.Shared.Exeptions;
using System.Net;

namespace PointOfSale.Identity.Roles.Exceptions
{
    public class PermissionsExistsException(string message = "Permitions you are trying to assing already exists in that Role") : GlobalExceptionError(HttpStatusCode.BadRequest, message)
    {
    }
}
