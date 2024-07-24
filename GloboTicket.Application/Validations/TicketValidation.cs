using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GloboTicket.Application.Common.Extensions;
using GloboTicket.Application.Common.Settings;
using GloboTicket.Application.Models;

namespace GloboTicket.Application.Validations
{
    public class TicketValidation : AbstractValidator<TicketModel>
    {
        public TicketValidation()
        {
            //RuleFor(x => x.MobileNumber)
            //    .Cascade(CascadeMode.Stop)
            //    .NotNull()
            //    .IsValidPhone()
            //    .WithError(Error.InvalidMobileNumber, "'{PropertyValue}'", "'{PropertyName}'");

            RuleFor(x => x.Title)
                .Cascade(CascadeMode.Stop)
                .Must(x => !string.IsNullOrEmpty(x))
                .WithError(Error.ArgumentNull, "'{PropertyName}'");

            RuleFor(x => x.Description)
                .Cascade(CascadeMode.Stop)
                .Must(x => !string.IsNullOrEmpty(x))
                .WithError(Error.ArgumentNull, "'{PropertyName}'");
        }
    }

}
