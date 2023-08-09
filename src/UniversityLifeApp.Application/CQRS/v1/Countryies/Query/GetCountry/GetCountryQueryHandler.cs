using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Countries.GetCountry;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.Countryies.Query.GetCountry
{
    public class GetCountryQueryHandler : IRequestHandler<GetCountryQuery, ApiResult<List<GetCountryResponse>>>
    {
        private readonly ICountryService _countryService;

        public GetCountryQueryHandler(ICountryService countryService)
        {
            _countryService = countryService;
        }
        public Task<ApiResult<List<GetCountryResponse>>> Handle(GetCountryQuery request, CancellationToken cancellationToken)
        {
            var result = _countryService.GetCountry();
            return result;
        }
    }
}
