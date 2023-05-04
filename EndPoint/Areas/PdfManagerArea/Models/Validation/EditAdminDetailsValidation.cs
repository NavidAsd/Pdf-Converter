using FluentValidation;

namespace EndPoint.Areas.PdfManagerArea.Models.Validation
{
    public class EditAdminDetailsValidation : AbstractValidator<RequestEditAdminDetailsViewModel>
    {
        public EditAdminDetailsValidation()
        {
            RuleFor(x => x.Email)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Please fill in the blank field")
                .NotNull().WithMessage("Please fill in the blank field")
                .EmailAddress().WithMessage("Please enter a valid email")
                .Must(BeAValidPostcode).WithMessage("Please do not use unauthorized characters");

            RuleFor(x => x.Password)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .NotEmpty().WithMessage("Please fill in the blank field")
               .NotNull().WithMessage("Please fill in the blank field")
               .Length(6, 50).WithMessage("Incorrect password")
               .Must(BeAValidPostcode).WithMessage("Please do not use unauthorized characters");
            
            RuleFor(x => x.FullName)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .NotEmpty().WithMessage("Please fill in the blank field")
               .NotNull().WithMessage("Please fill in the blank field")
               .Length(3, 75).WithMessage("Your Name must be between 3 and 75 characters long")
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
