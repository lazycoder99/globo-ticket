using GloboTicket.Application.Common.Extensions;
using GloboTicket.Application.Common.Settings;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GloboTicket.Web.Common
{
    public static class HttpResponseExtensions
    {
        public static async Task<HttpResponse> RecordNotFound(this HttpResponse response)
        {
            response.StatusCode = StatusCodes.Status400BadRequest;
            response.ContentType = "application/json";
            var responseBody = new ProblemDetails{ Status = (int)Error.RecordNotFound, Title = Error.RecordNotFound.GetMessage() };
            await response.WriteAsync(JsonConvert.SerializeObject(responseBody));
            await response.CompleteAsync();
            return response;
        }

        public static async Task WriteCustomStatusCodeAsync(this HttpResponse response, int statusCode, string message = null)
        {
            response.StatusCode = statusCode; // Set the custom status code
            if (!string.IsNullOrEmpty(message))
            {
                // Write the custom message to the response body if provided
                await response.WriteAsync(message);
            }
        }
    }
}
