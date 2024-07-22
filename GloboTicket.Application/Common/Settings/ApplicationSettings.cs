
namespace GatewaySvc.Application.Common.Settings
{
    public static class ApplicationSettings
    {
        public static bool EnableGatewayRules => ConfigProvider.Find("EnableGatewayRules", false);
        public static string UsePreviewCache => ConfigProvider.Find("UsePreviewCache", "");
        public static string UseMockData => ConfigProvider.Find("UseMockData", "");
        public static string UseWebHook => ConfigProvider.Find("UseWebHook", "");
        public static int RecordDumpSize => ConfigProvider.Find("RecordDumpSize", 10000);
        public static int PinCodeMinimumLength => ConfigProvider.Find("PinCodeMinimumLength", 10000);
        public static int PinCodeMaximumLength => ConfigProvider.Find("PinCodeMaximumLength", 99999);
        public static int PincodeMaximumAttempt => ConfigProvider.Find("PincodeMaximumAttempt", 3);
        public static int PinCodeExpireInMinute => ConfigProvider.Find("PinCodeExpireInMinute", 30);
        public static string DemoPinCode => ConfigProvider.Find("DemoPinCode", "45678");
        public static bool AddAccountPinVerification => ConfigProvider.Find("AddAccountPinVerification", true);
        public static bool SendPinCodeLive => ConfigProvider.Find("SendPinCodeLive", false);
        public static string SMSLocalFolderPath => ConfigProvider.Find("SMSLocalFolderPath", "");
        public static string EmailLocalFolderPath => ConfigProvider.Find("EmailLocalFolderPath", "");
        public static string SmsProvider => ConfigProvider.Find("SmsProvider", "");
        public static int PaymentLinkExpiryInMinute => ConfigProvider.Find("PaymentLinkExpiryInMinute", 30);
        public static string CardVerificationLevel => ConfigProvider.Find("CardVerificationLevel", "");
        public static string ValidationDisallowedLinks => ConfigProvider.Find("ValidationDisallowedLinks", "");
        #region Plivo
        public static string PlivoBaseUrl => ConfigProvider.Find("PlivoBaseUrl", "");
        public static string PlivoAuthId => ConfigProvider.Find("PlivoAuthId", "");
        public static string PlivoAuthToken => ConfigProvider.Find("PlivoAuthToken", "");
        public static string PlivoSrcMobileNumber => ConfigProvider.Find("PlivoSrcMobileNumber", "");
        public static string PlivoSrcShortCode => ConfigProvider.Find("PlivoSrcShortCode", "");
        #endregion

        #region Twilio 
        public static string TwilioBaseUrl => ConfigProvider.Find("TwilioBaseUrl", "");
        public static string TwilioAccountSID => ConfigProvider.Find("TwilioAccountSID", "");
        public static string TwilioAuthToken => ConfigProvider.Find("TwilioAuthToken", "");
        public static string TwilioSrcMobileNumber => ConfigProvider.Find("TwilioSrcMobileNumber", "");
        public static string TwilioSrcShortCode => ConfigProvider.Find("TwilioSrcShortCode", "");
        #endregion

        #region Email sending (SMTP, SendGrid)
        public static string SenderEmail => ConfigProvider.Find("SenderEmail", "");
        public static string SMTPServer => ConfigProvider.Find("SMTPServer", "");
        public static string SMTPPassword => ConfigProvider.Find("SMTPPassword", "");
        public static string SMTPUsername => ConfigProvider.Find("SMTPUsername", "");
        public static int SMTPPort => ConfigProvider.Find("SMTPPort", 587);
        public static bool SMTPAuthenticationRequired => ConfigProvider.Find("SMTPAuthenticationRequired", true);
        public static bool IsSSL => ConfigProvider.Find("IsSSL", true);
        public static string DefaultSender => ConfigProvider.Find("DefaultSender", "");
        public static string TestModeRecipient => ConfigProvider.Find("TestModeRecipient", "");
        public static string PinCodeHtmlBodyTemplete => ConfigProvider.Find("PinCodeHtmlBodyTemplete", "");
        public static string PinCodeEmailSubject => ConfigProvider.Find("PinCodeEmailSubject", "Payactiv Validation Pin");

        #endregion

        #region SendGrid 
        public static string SendGridBaseUrl => ConfigProvider.Find("SendGridBaseUrl", "");
        public static string SendGridVersion => ConfigProvider.Find("SendGridVersion", "");
        public static string SendGridApiKey => ConfigProvider.Find("SendGridApiKey", "");
        public static string SendGridAccountSID => ConfigProvider.Find("SendGridAccountSID", "");
        public static string SendGridAuthToken => ConfigProvider.Find("SendGridAuthToken", "");
        #endregion


        #region Bank
        
        #endregion

        #region Payactiv Card
        #endregion

        #region Amazon
        #endregion


        #region Message Template 
        public static string PinCodeSMSMessageTemplate => ConfigProvider.Find("PinCodeSMSMessageTemplate", "");
        #endregion
    }
}
