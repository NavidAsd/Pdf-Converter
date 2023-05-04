using FluentValidation;

namespace EndPoint.Areas.PdfManagerArea.Models.Validation
{
    public class UserChangePassValidation : AbstractValidator<UserChangePassViewModel>
    {
        public UserChangePassValidation()
        {
            RuleFor(x => x.NewPass)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .NotEmpty().WithMessage("Please fill in the blank field")
               .NotNull().WithMessage("Please fill in the blank field")
               .Length(6, 50).WithMessage("Incorrect password")
               .Must(BeAValidPostcode).WithMessage("Please do not use unauthorized characters");
            
            RuleFor(x => x.RepPass)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .NotEmpty().WithMessage("Please fill in the blank field")
               .NotNull().WithMessage("Please fill in the blank field")
               .Length(6, 50).WithMessage("Incorrect password")
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
