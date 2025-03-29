using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PointOfSale.Shared.Exeptions;

namespace PointOfSale
{
    public class CustomExceptionHandlerFilter(ILogger<CustomExceptionHandlerFilter> logger) : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var problemDetails = new ProblemDetails();

            if (context.Exception is GlobalExceptionError e)
            {

                problemDetails.Detail = e.Message;
                problemDetails.Status = ((int)e.StatusCode);
            }
            else
            {
                problemDetails.Detail = "Internal Server Error";
                problemDetails.Status = StatusCodes.Status500InternalServerError;
            }
            logger.LogError("{ProblemDetail}", problemDetails.Detail);

            context.Result = new ObjectResult(problemDetails) { StatusCode = problemDetails.Status };

            context.ExceptionHandled = true;
        }

    }
}
