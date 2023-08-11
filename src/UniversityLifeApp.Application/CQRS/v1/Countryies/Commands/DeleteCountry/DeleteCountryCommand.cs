using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Countries.DeleteCountry;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.Countryies.Commands.DeleteCountry
{
    public class DeleteCountryCommand:IRequest<ApiResult<DeleteCountryResponse>>
    {
        public DeleteCountryCommand(int countryId)
        {
            CountryId = countryId;
        }
        public int CountryId { get; set; }
    }
}
