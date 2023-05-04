using FluentValidation;

namespace EndPoint.Areas.PdfManagerArea.Models.Validation
{
    public class UpdateOnePartAdditionalHelpValidation : AbstractValidator<UpdateOnePartAdditionalViewModel>
    {
        public UpdateOnePartAdditionalHelpValidation()
        {
            RuleFor(x => x.BlockTitle)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Please fill in the blank field")
                .NotNull().WithMessage("Please fill in the blank field")
                .Length(3, 80).WithMessage("Title can not be less than 3 and more than 80 characters");
            //.Must(BeAValidPostcode).WithMessage("Please do not use unauthorized characters");

            RuleFor(x => x.Text)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .NotEmpty().WithMessage("Please fill in the blank field")
               .NotNull().WithMessage("Please fill in the blank field");
               //.Must(BeAValidPostcode).WithMessage("Please do not use unauthorized characters");
        }
        private bool BeAValidPostcode(string input)
        {
            if (input.Contains("!") || input.Contains("$") || input.Contains("'") || input.Contains("%"))
            {
                return false;
            }
            else
                return true;
        }
    }
}
