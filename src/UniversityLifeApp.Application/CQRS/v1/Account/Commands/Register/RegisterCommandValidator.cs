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
        }
    }
}
