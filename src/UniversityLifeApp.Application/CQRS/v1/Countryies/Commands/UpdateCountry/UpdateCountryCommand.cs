using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Countries.UpdateCountrt;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.Countryies.Commands.UpdateCountry
{
    public class UpdateCountryCommand:IRequest<ApiResult<UpdateCountryResponse>>
    {
        public UpdateCountryCommand(UpdateCountryRequest request, int countryId)
        {
            Request = request;
            CountryId = countryId;
        }
        public int CountryId { get; set; }  
        public UpdateCountryRequest Request { get; set; }
    }
}
