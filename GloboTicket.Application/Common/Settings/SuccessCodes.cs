using System.ComponentModel;

namespace GloboTicket.Application.Common.Settings
{
    public enum Success : int
    {
        #region Generic Codes
        [Description("Request Completed Succesfully.")]
        Success,

        [Description("Email Sent Successfully.")]
        EmailSendSuccessfully,
        #endregion

        // you can add other codes as well
    }
}