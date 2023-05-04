using FluentValidation;

namespace EndPoint.Areas.PdfManagerArea.Models.Validation
{
    public class UpdateAboutUsValidation : AbstractValidator<UpdateAboutUsViewModel>
    {
        public UpdateAboutUsValidation()
        {
            RuleFor(x => x.Text)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Please fill in the blank field")
                .NotNull().WithMessage("Please fill in the blank field");
        }
    }
}
