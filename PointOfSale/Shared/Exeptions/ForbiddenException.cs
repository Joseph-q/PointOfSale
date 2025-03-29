using System.Net;

namespace PointOfSale.Shared.Exeptions
{
    public class ForbiddenException(string message) : GlobalExceptionError(HttpStatusCode.Forbidden, message)
    {
    }
}
