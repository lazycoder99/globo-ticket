using System.Text.RegularExpressions;
using FluentValidation;
using FluentValidation.Validators;

namespace GloboTicket.Application.Validations.CustomValidator
{
    public class LuhnCreditCardValidator<T> : PropertyValidator<T, string?>
    {
        public override string Name => "CreditCard";

        public override bool IsValid(ValidationContext<T> context, string? value)
        {
            return IsCreditCardValid(value ?? string.Empty);
        }

        private static bool IsCreditCardValid(string creditCardNum)
        {
            if (!Regex.IsMatch(creditCardNum, @"^\d+$")) return false;
            else if (creditCardNum.Length != 16) return false;

            //Luhn algorithm
            var total = 0;
            for (var i = 0; i < creditCardNum.Length; i++)
            {
                var num = creditCardNum[i] - 48;
                num *= (i % 2 == 0) ? 2 : 1;
                total += (num >= 10) ? GetSumOfDigits(num) : num;
            }

            return total % 10 == 0;
        }

        private static int GetSumOfDigits(int num)
        {
            var lastDigit = 0;
            if (num <= 0) return lastDigit;

            lastDigit = num % 10;
            num = num / 10;
            lastDigit += GetSumOfDigits(num);

            return lastDigit;
        }
    }
}
