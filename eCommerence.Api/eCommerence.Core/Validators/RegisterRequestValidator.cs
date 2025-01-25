using eCommerence.Core.DTO;
using FluentValidation;

namespace eCommerence.Core.Validators;

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        //Email
        RuleFor(temp => temp.Email)
    .NotEmpty().WithMessage("Email is required")
    .EmailAddress().WithMessage("Invalid email address format");
        RuleFor(temp => temp.Password).NotEmpty().WithMessage("Password Can't be Balnk");
        RuleFor(temp => temp.PersonName)
.NotEmpty().WithMessage("PersonName is required");
        RuleFor(temp => temp.Gender).NotEmpty().WithMessage("Gender Can't be Balnk");
    }
}
