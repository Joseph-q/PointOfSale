using System.Net;

namespace PointOfSale.Shared.Exeptions
{
    public class GlobalExceptionError : Exception
    {
        public HttpStatusCode StatusCode { get; }

        public GlobalExceptionError(HttpStatusCode statusCode, string message)
           : base(message)
        {
            StatusCode = statusCode;
        }

    }
}
