using FluentValidation;

namespace EndPoint.Areas.PdfManagerArea.Models.Validation
{
    public class UpdateMetatagKeywordValidation : AbstractValidator<RequestUpdateMetatagKeywordViewModel>
    {
        public UpdateMetatagKeywordValidation()
        {
            RuleFor(x => x.Keyword)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Please fill in the blank field")
                .NotNull().WithMessage("Please fill in the blank field")
                .Length(2, 30).WithMessage("Word can not be less than 2 and more than 30 characters");
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
