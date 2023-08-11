using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Countries.AddCountry;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.Countryies.Commands.AddCountry
{
    public class AddCountryCommand:IRequest<ApiResult<AddCountryResponse>>
    {
        public AddCountryCommand(AddCountryRequest request)
        {
            Request = request; 
        }
        public AddCountryRequest Request { get; set; }
    }
}
