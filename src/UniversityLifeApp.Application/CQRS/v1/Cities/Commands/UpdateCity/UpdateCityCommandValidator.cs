using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLifeApp.Application.CQRS.v1.Cities.Commands.UpdateCity
{
    public class UpdateCityCommandValidator:AbstractValidator<UpdateCityCommand>
    {
        public UpdateCityCommandValidator()
        {
            RuleFor(x => x.Request.Name)
                .MinimumLength(3).WithMessage("The city name must contain at least 3 letters.")
                .MaximumLength(85).WithMessage("The city name can contain up to 85 characters.")
                .NotEmpty().WithMessage("The city name cannot be empty.");
            RuleFor(x => x.Request.Latitude).NotEmpty();
            RuleFor(x => x.Request.Longitude).NotEmpty();
            RuleFor(x => x.Request.CountryId).NotEmpty();
        }
    }
}
