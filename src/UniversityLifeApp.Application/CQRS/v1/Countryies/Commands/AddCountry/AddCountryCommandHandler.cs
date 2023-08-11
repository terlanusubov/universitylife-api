using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Countries.AddCountry;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.Countryies.Commands.AddCountry
{
    public class AddCountryCommandHandler:IRequestHandler<AddCountryCommand,ApiResult<AddCountryResponse>>
    {
        private readonly ICountryService _countryService;

        public AddCountryCommandHandler(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public async Task<ApiResult<AddCountryResponse>> Handle(AddCountryCommand request, CancellationToken cancellationToken)
        {
            var result =await _countryService.AddCountry(request);
            return result;
        }
    }
}
