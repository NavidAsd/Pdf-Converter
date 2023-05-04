using Common;
using FluentValidation;
using System;

namespace EndPoint.Areas.PdfManagerArea.Models.Validation
{
    public class UserPassRecoveryCodeValidation : AbstractValidator<UserPassRecoveryCodeViewModel>
    {
        public UserPassRecoveryCodeValidation()
        {
            RuleFor(x => x.Code.ToString())
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Please fill in the blank field")
                .NotNull().WithMessage("Please fill in the blank field")
                .Must(BeAValidPostcode).WithMessage("Please do not use unauthorized characters")
                .Length((int)Math.Floor(Math.Log10(GetPath.GetMinCode()) + 1), (int)Math.Floor(Math.Log10(GetPath.GetMaxCode()) + 1)).WithMessage("The number of digits entered is incorrect"); ;
        }
        private bool BeAValidPostcode(string input)
        {
            if (input.Contains("!") || input.Contains("$") || input.Contains("'") || input.Contains("%") || input.Contains("#") || input.Contains("/") || input.Contains("//"))
            {
                return false;
            }
            else
                return true;
        }
    }
}
