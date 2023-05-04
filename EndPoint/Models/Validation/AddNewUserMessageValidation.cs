using FluentValidation;

namespace EndPoint.Models.Validation
{
    public class AddNewUserMessageValidation : AbstractValidator<AddNewUserMessageViewModel>
    {
        public AddNewUserMessageValidation()
        {
            RuleFor(x => x.Email)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Please fill in the blank field")
                .NotNull().WithMessage("Please fill in the blank field")
                .EmailAddress().WithMessage("Please enter a valid email")
                .Must(BeAValidPostcode).WithMessage("Please do not use unauthorized characters");


            RuleFor(x => x.Message)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Please fill in the blank field")
                .NotNull().WithMessage("Please fill in the blank field")
                .Length(6, 850).WithMessage("Your Message can not be less than 6 and more than 850 characters")
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
