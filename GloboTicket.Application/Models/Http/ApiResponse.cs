using GloboTicket.Application.Common.Extensions;

namespace GloboTicket.Application.Models.Http
{
    public record ErrorDetail
    {
        public string errorCode { get; set; } = string.Empty;
        public string errorMessage { get; set; } = string.Empty;
        public string propertyName { get; set; } = string.Empty;
        public string attemptedValue { get; set; } = string.Empty;
    }

    public class ApiResponse<TDestination>
    {
        public bool Success { get; set; }
        public string Title { get; set; }
        public TDestination? Data { get; set; }
        public int Status { get; set; }
        public ErrorDetail[]? Errors { get; set; } = null;
        public string? TraceId { get; set; } = null;

        public ApiResponse(ResultSet resultSet)
        {
            this.Success = resultSet.Success;

            if (this.Success)
            {
                this.Data = resultSet.Data;
                this.Title = resultSet.SuccessCode.GetMessage();
                this.Status = 200;
            }
            else
            {
                //this.ErrorDetail = GetErrorDetails(resultSet.Errors);
                Title = "One or more errors occured.";
                Errors = resultSet.ErrorDetails;
                this.Status = 400;
            }
        }
    }
}
