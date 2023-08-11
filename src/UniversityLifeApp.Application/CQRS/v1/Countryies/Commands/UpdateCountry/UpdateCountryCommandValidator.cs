using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityLifeApp.Application.CQRS.v1.Countryies.Commands.AddCountry;

namespace UniversityLifeApp.Application.CQRS.v1.Countryies.Commands.UpdateCountry
{
    internal class UpdateCountryCommandValidator : AbstractValidator<UpdateCountryCommand>
    {
        public UpdateCountryCommandValidator()
        {
            RuleFor(x => x.Request.Name)
               //.MinimumLength(3).WithMessage("The country name must contain at least 3 letters.")
               .MaximumLength(50).WithMessage("The country name can contain up to 50 characters.")
               .NotEmpty().WithMessage("The city name cannot be empty.");
        }
    }
}
