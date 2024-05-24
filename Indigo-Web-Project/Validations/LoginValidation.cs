using FluentValidation;
using Indigo_Web_Project.ViewModels;

namespace Indigo_Web_Project.Validations
{
    public class LoginValidation:AbstractValidator<LoginVM>
    {
        public LoginValidation()
        {
            RuleFor(x => x.Email).NotEmpty();

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(8);
        }

    }
}
