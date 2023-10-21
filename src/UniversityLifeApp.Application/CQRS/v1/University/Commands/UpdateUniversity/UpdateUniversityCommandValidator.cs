using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLifeApp.Application.CQRS.v1.University.Commands.UpdateUniversity
{
    public class UpdateUniversityCommandValidator:AbstractValidator<UpdateUniversityCommand>
    {
        public UpdateUniversityCommandValidator()
        {
            RuleFor(x => x.Request.Name)
                //.MinimumLength(3).WithMessage("The name must contain at least 3 letters.")
                .MaximumLength(100).WithMessage("The name can contain up to 100 characters.")
                .NotEmpty().WithMessage("The name cannot be empty.");

            RuleFor(x => x.Request.Longitude).NotEmpty();
            RuleFor(x => x.Request.Latitude).NotEmpty();
            RuleFor(x => x.Request.CityId).NotEmpty();
        }
    }
}
