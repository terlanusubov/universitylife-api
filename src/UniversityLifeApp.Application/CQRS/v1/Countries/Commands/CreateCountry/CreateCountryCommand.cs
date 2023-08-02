using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Countries.AddCountry;
using UniveristyLifeApp.Models.v1.Users.AddUser;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.CQRS.v1.Users.Commands.AddUser;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.Countries.Commands.CreateCountry
{
    public class CreateCountryCommand:IRequest<ApiResult<CountryResponse>>
    {
        public CountryRequest Model { get; set; }
        public CreateCountryCommand(CountryRequest request)
        {
            Model = request;
        }
        public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, ApiResult<CountryResponse>>
        {
            private readonly ICountryService _countryService;

            public CreateCountryCommandHandler(ICountryService countryService)
            {
                _countryService = countryService;
            }
            public Task<ApiResult<CountryResponse>> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
            {
                CountryRequest country = new CountryRequest
                {
                     Name = "Eng",
                     CountryStatusId = 1,
                };
                var result = _countryService.CreateCountry(country);
                return result;
            }
        }
    }
}
