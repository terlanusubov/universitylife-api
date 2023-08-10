using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Countries.DeleteCountry;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.Countryies.Commands.DeleteCountry
{
    public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand, ApiResult<DeleteCountryResponse>>
    {
        private readonly ICountryService _countryService;

        public DeleteCountryCommandHandler(ICountryService countryService)
        {
            _countryService = countryService;
        }
        public Task<ApiResult<DeleteCountryResponse>> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
        {
            var resyult = _countryService.DeleteCountry(request.CountryId);
            return resyult;
        }
    }
}
