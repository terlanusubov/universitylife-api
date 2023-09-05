using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLifeApp.Application.CQRS.v1.Account.Commands.Update
{
    public class UpdateCommandValidator:AbstractValidator<UpdateCommand>
    {
        public UpdateCommandValidator()
        {
            RuleFor(x => x.Request.Name)
                .NotEmpty().WithMessage("The Name field cannot be empty.")
                //.MinimumLength(2).WithMessage("The name must contain at least 2 letters.")
                .MaximumLength(30).WithMessage("The name can contain up to 30 characters.");
            RuleFor(x => x.Request.Surname)
                //.MinimumLength(2).WithMessage("The surname must contain at least 2 letters.")
                .MaximumLength(50).WithMessage("The surname can contain up to 30 characters.")
                .NotEmpty().WithMessage("The Surname field cannot be empty.");
            RuleFor(x => x.Request.PhoneNumber)
                .NotEmpty().WithMessage("The Surname field cannot be empty.")
                .Matches(@"^\+(?:[0-9]?){6,14}[0-9]$").WithMessage("The phone number does not match the format.");
        }
    }
}
