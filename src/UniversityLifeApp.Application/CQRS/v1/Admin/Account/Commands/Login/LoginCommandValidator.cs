using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLifeApp.Application.CQRS.v1.Admin.Account.Commands.Login
{
    public class LoginCommandValidator:AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(x => x.Request.Email)
                .Matches(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$").WithMessage("E-mail was not entered correctly.")
                .NotEmpty().WithMessage("The E-mail field cannot be empty.");

            RuleFor(x => x.Request.Password)
                .NotEmpty().WithMessage("The Name field cannot be empty.")
                .MinimumLength(8).WithMessage("Password must contain at least 8 characters.")
                .MaximumLength(32).WithMessage("The password can contain a maximum of 32 characters.");
        }
    }
}
