using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Countries.UpdateCountrt;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.Countryies.Commands.UpdateCountry
{
    public class UpdateCountryCommandHnadler
    {
        private readonly ICountryService _cityService;
        public UpdateCountryCommandHnadler(ICountryService cityService)
        {
            _cityService = cityService;
        }
        public async Task<ApiResult<UpdateCountryResponse>> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
        {
            var result = await _cityService.UpdateCountry(request, request.CountryId);

            return result;
        }
    }
}
