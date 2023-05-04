using FluentValidation;

namespace EndPoint.Areas.PdfManagerArea.Models.Validation
{
    public class UpdateTreeHelpStepValidation : AbstractValidator<RequestUpdateTreeHelpStepViewModel>
    {
        public UpdateTreeHelpStepValidation()
        {
            RuleFor(x => x.Step1)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Please fill in the blank field")
                .NotNull().WithMessage("Please fill in the blank field")
                .Length(6, 220).WithMessage("Step1 can not be less than 6 and more than 220 characters");

            RuleFor(x => x.Step2)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Please fill in the blank field")
                .NotNull().WithMessage("Please fill in the blank field")
                .Length(6, 220).WithMessage("Step2 can not be less than 6 and more than 220 characters");

            RuleFor(x => x.Step3)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Please fill in the blank field")
                .NotNull().WithMessage("Please fill in the blank field")
                .Length(6, 220).WithMessage("Step3 can not be less than 6 and more than 220 characters");

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
