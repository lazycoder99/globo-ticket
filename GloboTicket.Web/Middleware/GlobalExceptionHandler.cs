using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace GloboTicket.Web.Middleware
{
    internal sealed class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            logger.LogError(exception, "Global Exception: {Message}", exception.Message);

            // todo:: 
            var problemDetails = new ProblemDetails
            {
                Status = 550,
                Title = $"Something went wrong, TraceId : {httpContext.TraceIdentifier}"
            };

            if (exception is SqlException || exception is DbUpdateException)
                problemDetails.Status = 450;

            httpContext.Response.StatusCode = problemDetails.Status.Value;

            await httpContext.Response
                .WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }
    }
}
