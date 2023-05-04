using FluentValidation;

namespace EndPoint.Areas.PdfManagerArea.Models.Validation
{
    public class AddNewFrequentlyQuestionValidation : AbstractValidator<AddNewFrequentlyQuestionViewModel>
    {
        public AddNewFrequentlyQuestionValidation()
        {
            RuleFor(x => x.Question)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Please fill in the blank field")
                .NotNull().WithMessage("Please fill in the blank field");
                //.Length(3, 250).WithMessage("Question can not be less than 3 and more than 250 characters");

            RuleFor(x => x.Answer)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .NotEmpty().WithMessage("Please fill in the blank field")
               .NotNull().WithMessage("Please fill in the blank field");
               //.Length(8, 680).WithMessage("Answer can not be less than 8 and more than 680 characters");
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
