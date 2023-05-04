using FluentValidation;

namespace EndPoint.Areas.PdfManagerArea.Models.Validation
{
    public class EdtiMetatagValidation : AbstractValidator<RequestEditMetatagViewModel>
    {
        public EdtiMetatagValidation()
        {
            RuleFor(x => x.Title)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Please fill in the blank field")
                .NotNull().WithMessage("Please fill in the blank field")
                .Length(3, 80).WithMessage("Title can not be less than 3 and more than 80 characters");
            //.Must(BeAValidPostcode).WithMessage("Please do not use unauthorized characters");

            RuleFor(x => x.Description)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .NotEmpty().WithMessage("Please fill in the blank field")
               .NotNull().WithMessage("Please fill in the blank field")
               .Length(5, 400).WithMessage("Description can not be less than 5 and more than 400 characters");
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
