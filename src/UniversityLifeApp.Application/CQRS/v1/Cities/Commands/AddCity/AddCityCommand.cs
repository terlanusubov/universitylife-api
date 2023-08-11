using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Cities.AddCity;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.Cities.Commands.AddCity
{
    public class AddCityCommand:IRequest<ApiResult<AddCityResponse>>
    {
        public AddCityCommand(AddCityRequest request)
        {
            Request = request;
        }

        public AddCityRequest Request { get; set; }
    }
}
