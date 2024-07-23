using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.Application.Common.Helpers
{
    // helper class for common utilities
    public static class Util
    {
        public static string GetPlainMobileNumber(string? mobileNumber)
        {
            if (string.IsNullOrEmpty(mobileNumber))
                return string.Empty;

            return mobileNumber.Replace("+", "").Replace("(", "").Replace(")", "").Replace("-", "");
        }
    }
}
