using FluentValidation;

namespace EndPoint.Areas.PdfManagerArea.Models.Validation
{
    public class UpdateBasicAdditionalHelpValidation : AbstractValidator<UpdateAdditionalViewModel>
    {
        public UpdateBasicAdditionalHelpValidation()
        {
            RuleFor(x => x.ServiceDescription)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Please fill in the blank field")
                .NotNull().WithMessage("Please fill in the blank field");
            //.Must(BeAValidPostcode).WithMessage("Please do not use unauthorized characters");

            RuleFor(x => x.Title)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .NotEmpty().WithMessage("Please fill in the blank field")
               .NotNull().WithMessage("Please fill in the blank field");
            
            RuleFor(x => x.HelpContext)
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
