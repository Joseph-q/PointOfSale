using System.Net;

namespace PointOfSale.Shared.Exeptions
{
    public class UnauthorizedException : GlobalExceptionError
    {
        public UnauthorizedException() : base(HttpStatusCode.Unauthorized, "authentication failed")
        {
        }

        public UnauthorizedException(string message) : base(HttpStatusCode.Unauthorized, message)
        {
        }

    }
}
