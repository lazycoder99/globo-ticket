using GloboTicket.Application.Contracts.Services;
using Serilog.Context;

namespace GloboTicket.Web.Middleware
{
    // you can implement any validation logic for application
    public class ValidationMiddleware(RequestDelegate next, ILogger<ValidationMiddleware> logger)
    {
        public async Task InvokeAsync(HttpContext context, ITicketService ticketService)
        {
            context.Request.Headers.TryGetValue("X-Api-Key", out var apiKey);
            if (string.IsNullOrEmpty(apiKey))
            {
                logger.LogWarning($"API key is missing");
            }

            // Call the next middleware in the pipeline
            await next(context);
        }
    }
}
