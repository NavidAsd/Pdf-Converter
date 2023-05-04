using FluentValidation;

namespace EndPoint.Models.Validation
{
    public class UploadSecurityFileValidation : AbstractValidator<UploadSecurityFileViewModel>
    {
        public UploadSecurityFileValidation()
        {
            RuleFor(x => x.Password)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Please fill in the blank field")
                .NotNull().WithMessage("Please fill in the blank field")
                .Must(BeAValidPostcode).WithMessage("Please do not use unauthorized characters");

            RuleFor(x => x.RePassword)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Please fill in the blank field")
                .NotNull().WithMessage("Please fill in the blank field")
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
