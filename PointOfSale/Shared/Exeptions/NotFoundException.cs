using System.Net;

namespace PointOfSale.Shared.Exeptions
{
    public class NotFoundException(String message) : GlobalExceptionError(HttpStatusCode.NotFound, message)
    {
    }
}
