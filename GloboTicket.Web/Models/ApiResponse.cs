using GloboTicket.Application.Common.Extensions;
using GloboTicket.Application.Models.Http;

namespace GloboTicket.Web.Models
{
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
