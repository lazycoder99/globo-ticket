using System.Text.RegularExpressions;
using FluentValidation;
using FluentValidation.Validators;

namespace GloboTicket.Application.Validations.CustomValidator
{
    public class IsValidMobileNumber<T> : PropertyValidator<T, string?>
    {
        private const string Expression = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
        private static readonly Regex Regex = CreateRegEx();
        public override string Name => "IsValidMobileNumber";

        public override bool IsValid(ValidationContext<T> context, string? value)
        {
            if (value == null) return false;
            return Regex.IsMatch(value);
        }

        protected override string GetDefaultMessageTemplate(string errorCode)
        {
            return Localized(errorCode, Name);
        }

        private static Regex CreateRegEx()
        {
            const RegexOptions options = RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture;
            return new Regex(Expression, options, TimeSpan.FromSeconds(2.0));
        }
    }
}
