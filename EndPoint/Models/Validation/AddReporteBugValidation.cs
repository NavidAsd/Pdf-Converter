using FluentValidation;

namespace EndPoint.Models.Validation
{
    public class AddReporteBugValidation : AbstractValidator<AddRepoteBugViewModel>
    {
        public AddReporteBugValidation()
        {
            RuleFor(x => x.Email)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Please fill in the blank field")
                .NotNull().WithMessage("Please fill in the blank field")
                .EmailAddress().WithMessage("Please enter a valid email")
                .Must(BeAValidPostcode).WithMessage("Please do not use unauthorized characters");

            RuleFor(x => x.Problem)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Please fill in the blank field")
                .NotNull().WithMessage("Please fill in the blank field")
                .Length(6, 650).WithMessage("Your Message can not be less than 6 and more than 650 characters")
                .Must(BeAValidPostcode).WithMessage("Please do not use unauthorized characters");
        }
        private bool BeAValidPostcode(string input)
        {
            if ( input.Contains("$") || input.Contains("%") || input.Contains("#") || input.Contains("/") || input.Contains("//"))
            {
                return false;
            }
            else
                return true;
        }
    }
}
