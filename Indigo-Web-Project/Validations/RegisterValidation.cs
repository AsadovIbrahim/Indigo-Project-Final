using FluentValidation;
using Indigo_Web_Project.ViewModels;

namespace Indigo_Web_Project.Validations
{
    public class RegisterValidation : AbstractValidator<RegisterVM>
    {
        public RegisterValidation()
        {
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(8);

            RuleFor(x => x.ConfirmPassword)
                 .NotEmpty()
                 .MinimumLength(8);
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MinimumLength(4);

            RuleFor(x => x.LastName)
                .NotEmpty()
                .MinimumLength(5);

        }
    }
}
