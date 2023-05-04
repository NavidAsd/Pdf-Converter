using FluentValidation;

namespace EndPoint.Areas.PdfManagerArea.Models.Validation
{
    public class EditServiceDetailsValidation : AbstractValidator<EditServiceDetailsViewModel>
    {
        public EditServiceDetailsValidation()
        {
            RuleFor(x => x.HelpContext)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Please fill in the blank field")
                .NotNull().WithMessage("Please fill in the blank field")
                .Length(8, 180).WithMessage("HelpContext can not be less than 8 and more than 180 characters");

            RuleFor(x => x.Description)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .NotEmpty().WithMessage("Please fill in the blank field")
               .NotNull().WithMessage("Please fill in the blank field")
               .Length(10, 350).WithMessage("Description can not be less than 10 and more than 350 characters");
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
