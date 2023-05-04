using FluentValidation;

namespace EndPoint.Models.Validation
{
    public class SendFileToEmailValidation : AbstractValidator<SendFileToEmailViewModel>
    {
        public SendFileToEmailValidation()
        {
            RuleFor(x => x.UserEmail)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Please fill in the blank field")
                .NotNull().WithMessage("Please fill in the blank field")
                .EmailAddress().WithMessage("Please enter a valid email")
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
