using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLifeApp.Application.CQRS.v1.OurService.Commands.CreateService
{
    public class CreateServiceCommandValidator:AbstractValidator<CreateServiceCommand>
    {
        public CreateServiceCommandValidator()
        {
            RuleFor(x => x.Request.Name)
                .NotNull().WithMessage("The Name field cannot be empty.")
                .MaximumLength(30).WithMessage("The name can contain up to 30 characters.");
            RuleFor(x => x.Request.Description)
                .NotNull().WithMessage("The Description field cannot be empty.")
                .MaximumLength(400).WithMessage("The name can contain up to 400 characters.");
            RuleFor(x => x.Request.ImageFile)
                .NotNull().WithMessage("The Image field cannot be empty");
        }
    }
}
