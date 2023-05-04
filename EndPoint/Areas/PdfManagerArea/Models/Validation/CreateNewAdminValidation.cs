using FluentValidation;

namespace EndPoint.Areas.PdfManagerArea.Models.Validation
{
    public class CreateNewAdminValidation : AbstractValidator<CreateNewAdminViewModel>
    {
        public CreateNewAdminValidation()
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
            
            RuleFor(x => x.RePassword)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .NotEmpty().WithMessage("Please fill in the blank field")
               .NotNull().WithMessage("Please fill in the blank field")
               .Length(6, 50).WithMessage("Incorrect password")
               .Must(BeAValidPostcode).WithMessage("Please do not use unauthorized characters");

            RuleFor(x => x.FullName)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .NotEmpty().WithMessage("Please fill in the blank field")
               .NotNull().WithMessage("Please fill in the blank field")
               .Length(3, 55).WithMessage("FullName can not be less than 3 and more than 55 characters")
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
