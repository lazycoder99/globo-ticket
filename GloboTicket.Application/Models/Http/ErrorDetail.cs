using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.Application.Models.Http
{
    public record ErrorDetail
    {
        public string errorCode { get; set; } = string.Empty;
        public string errorMessage { get; set; } = string.Empty;
        public string propertyName { get; set; } = string.Empty;
        public string attemptedValue { get; set; } = string.Empty;
    }
}
