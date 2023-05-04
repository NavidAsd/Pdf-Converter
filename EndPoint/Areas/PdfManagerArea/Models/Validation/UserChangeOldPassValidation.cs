using FluentValidation;

namespace EndPoint.Areas.PdfManagerArea.Models.Validation
{
    public class UserChangeOldPassValidation : AbstractValidator<UserChangeOldPassViewModel>
    {
        public UserChangeOldPassValidation()
        {

            RuleFor(x => x.OldPassword)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .NotEmpty().WithMessage("Please fill in the blank field")
               .NotNull().WithMessage("Please fill in the blank field")
               .Length(6, 50).WithMessage("The length of the password entered is not accepted")
               .Must(BeAValidPostcode).WithMessage("Please do not use unauthorized characters");
            
            RuleFor(x => x.NewPassword)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .NotEmpty().WithMessage("Please fill in the blank field")
               .NotNull().WithMessage("Please fill in the blank field")
               .Length(6, 50).WithMessage("The length of the password entered is not accepted")
               .Must(BeAValidPostcode).WithMessage("Please do not use unauthorized characters");
            
            RuleFor(x => x.RepPassword)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .NotEmpty().WithMessage("Please fill in the blank field")
               .NotNull().WithMessage("Please fill in the blank field")
               .Length(6, 50).WithMessage("The length of the password entered is not accepted")
               .Must(BeAValidPostcode).WithMessage("Please do not use unauthorized characters");
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
