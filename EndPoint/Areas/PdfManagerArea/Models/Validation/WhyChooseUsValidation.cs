using FluentValidation;

namespace EndPoint.Areas.PdfManagerArea.Models.Validation
{
    public class WhyChooseUsValidation : AbstractValidator<RequestUpdateWhyChooseUsViewModel>
    {
        public WhyChooseUsValidation()
        {
            RuleFor(x => x.Text)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Please fill in the blank field")
                .NotNull().WithMessage("Please fill in the blank field")
                .Length(8, 250).WithMessage("Privacy Text can not be less than 8 and more than 250 characters");


            RuleFor(x => x.Title)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Please fill in the blank field")
                .NotNull().WithMessage("Please fill in the blank field")
                .Length(3, 60).WithMessage("Title2 can not be less than 3 and more than 60 characters");


        }
        private bool BeAValidPostcode(string input)
        {
            if (input.Contains("!") || input.Contains("$") || input.Contains("'") || input.Contains("%") || input.Contains("#"))
            {
                return false;
            }
            else
                return true;
        }
    }
}
