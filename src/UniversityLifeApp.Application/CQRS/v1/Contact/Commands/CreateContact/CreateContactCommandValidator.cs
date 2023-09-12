using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLifeApp.Application.CQRS.v1.Contact.Commands.CreateContact
{
    public class CreateContactCommandValidator:AbstractValidator<CreateContactCommand>
    {
        public CreateContactCommandValidator()
        {
            RuleFor(x => x.Request.FullName)
                .MinimumLength(3).WithMessage("The FullName must contain at least 5 letters.")
                .MaximumLength(30).WithMessage("The FullName can contain up to 30 characters.")
                .NotEmpty().WithMessage("The FullName cannot be empty.");
            RuleFor(x => x.Request.FullName).NotEmpty();
            RuleFor(x => x.Request.Comment).NotEmpty();
            RuleFor(x => x.Request.Country).NotEmpty();
            RuleFor(x => x.Request.Email)
               .Matches(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$").WithMessage("E-mail was not entered correctly.")
               .NotEmpty().WithMessage("The E-mail field cannot be empty.");
            RuleFor(x => x.Request.Phone)
                .NotEmpty().WithMessage("The Surname field cannot be empty.")
                .Matches(@"^\+(?:[0-9]?){6,14}[0-9]$").WithMessage("The phone number does not match the format.");
        }
    }
}
