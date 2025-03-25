

using eCommerce.Core.DTO;
using FluentValidation;
using System.Collections.Generic;
using System.ComponentModel;

namespace eCommerce.Core.Validators
{
    public class LoginRequestValidator:AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            //email
            RuleFor(temp => temp.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email addres format");
            //password
            RuleFor(temp=>temp.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long")
                .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter")
                .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter")
                .Matches(@"\d").WithMessage("Password must contain at least one numeric digit")
                .Matches(@"[!@#$%^&*(),.?:{ }|<>]").WithMessage("Password must contain at least one special character");
        }
    }
}
