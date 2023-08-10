using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Account.Register;

namespace UniversityLifeApp.Application.CQRS.v1.Account.Commands.Register
{
    public class RegisterCommandValidator:AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.RegisterReguest.Name)
                .NotEmpty().WithMessage("The Name field cannot be empty.")
                //.MinimumLength(2).WithMessage("The name must contain at least 2 letters.")
                .MaximumLength(30).WithMessage("The name can contain up to 30 characters.");
            RuleFor(x => x.RegisterReguest.Email)
                .Matches(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$").WithMessage("E-mail was not entered correctly.")
                .NotEmpty().WithMessage("The E-mail field cannot be empty.");
            RuleFor(x => x.RegisterReguest.Surname)
                //.MinimumLength(2).WithMessage("The surname must contain at least 2 letters.")
                .MaximumLength(50).WithMessage("The surname can contain up to 30 characters.")
                .NotEmpty().WithMessage("The Surname field cannot be empty.");
            RuleFor(x => x.RegisterReguest.PhoneNumber)
                .NotEmpty().WithMessage("The Surname field cannot be empty.")
                .Matches(@"^\+(?:[0-9]?){6,14}[0-9]$").WithMessage("The phone number does not match the format.");
            RuleFor(x => x.RegisterReguest.Password)
                .NotEmpty().WithMessage("The Name field cannot be empty.")
                .MinimumLength(8).WithMessage("Password must contain at least 8 characters.")
                .MaximumLength(32).WithMessage("The password can contain a maximum of 32 characters.");
        }
    }
}
