using System.ComponentModel;

namespace GloboTicket.Application.Common.Settings
{
    public enum Error : int
    {
        #region Generic Codes

        [Description("No Implementation found for this endpoint.")]
        NoImplementation = 10004,

        [Description("Record not found.")] 
        RecordNotFound = 10006,

        [Description("An internal exception occurred.")]
        ExceptionRaised = 10007,

        [Description("Failed to process this request due to an internal error.")]
        Failed = 10008,

        [Description("Failed to format response due to an internal error.")]
        FailedToFormatResponse = 10009,

        [Description("Request payload is null.")]
        RequestIsNull = 10012,

        [Description("Data in request is empty.")]
        RequestDataIsEmpty = 10013,

        [Description("Data in request is null.")]
        RequestDataIsNull = 10014,

        [Description("Validation failed in this request.")]
        ValidationFailed = 10015,

        [Description("Validation failed for : {0}")]
        ValidationFailedFor = 10016,

        #endregion

        // you can add other codes as well
    }
}