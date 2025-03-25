using eCommerce.Core.DTO;
using FluentValidation;

namespace eCommerce.Core.Validators
{
    public class RegistrationRequestValidator:AbstractValidator<RegisterRequest>
    {
        public RegistrationRequestValidator()
        {
            //Email
            RuleFor(temp => temp.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid Email Address format");
            //Password           
                RuleFor(temp => temp.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long")
                .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter")
                .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter")
                .Matches(@"\d").WithMessage("Password must contain at least one numeric digit")
                .Matches(@"[!@#$%^&*(),.?:{ }|<>]").WithMessage("Password must contain at least one special character");
            //PersonName
            RuleFor(temp => temp.PersonName)
                .NotEmpty().WithMessage("Person Name is required")
                .Length(1, 50).WithMessage("Person name should be 1 to 50 character long");
            //Gender
            RuleFor(temp => temp.Gender)
                .IsInEnum().WithMessage("Invalid gender option");
        }
    }
}
