using FluentValidation.Results;
using GloboTicket.Application.Common.Extensions;
using GloboTicket.Application.Common.Settings;

namespace GloboTicket.Application.Models.Http
{
    public class ResultSet
    {
        public bool Success { get; private set; }
        public dynamic? Data { get; private set; }
        public ErrorDetail[]? ErrorDetails { get; set; } = null;
        public Success SuccessCode { get; private set; }

        public ResultSet()
        {
            Success = false;
        }

        public ResultSet(dynamic data, Success successCode = GloboTicket.Application.Common.Settings.Success.Success)
        {
            Success = true;
            Data = data;
            SuccessCode = successCode;
        }

        public ResultSet(params ErrorDetail[] errors)
        {
            Success = false;
            ErrorDetails = errors;
        }

        public ResultSet(params Error[] errors)
        {
            Success = false;
            ErrorDetails = new ErrorDetail[errors.Length];
            for (var i = 0; i < errors.Length; i++)
            {
                ErrorDetails[i] = new ErrorDetail
                {
                    errorMessage = errors[i].GetMessage(),
                    errorCode = ((int)errors[i]).ToString(),
                };
            }
        }

        public ResultSet(Error error, params object[] values)
        {
            Success = false;
            ErrorDetails =
            [
                new ErrorDetail
                {
                    errorCode = ((int)error).ToString(),
                    errorMessage = (values.Length <= 0) ? error.GetMessage() : string.Format(error.GetMessage(), values)
                }
            ];
        }

        public ResultSet(List<ValidationFailure> errors)
        {
            Success = false;
            ErrorDetails = new ErrorDetail[errors.Count];
            for (var i = 0; i < errors.Count; i++)
            {
                ErrorDetails[i] = new ErrorDetail
                {
                    errorCode = errors[i].ErrorCode,
                    errorMessage = errors.ElementAt(i).ErrorMessage
                };
            }
        }
    }
}
