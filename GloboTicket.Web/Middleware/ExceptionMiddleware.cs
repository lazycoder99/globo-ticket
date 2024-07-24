using System.Net;
using GloboTicket.Application.Common.Settings;

namespace GloboTicket.Web.Middleware
{
    public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                logger.LogError("Something went wrong [Global Exception]");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = new
            {
                Code = Error.Failed /*context.Response.StatusCode*/,
                Description = "Internal Server Error from the custom middleware."
            };

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
