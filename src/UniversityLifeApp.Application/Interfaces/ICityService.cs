using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Cities.AddCity;
using UniveristyLifeApp.Models.v1.Cities.GetCity;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.CQRS.v1.Cities.Commands.AddCity;

namespace UniversityLifeApp.Application.Interfaces
{
    public interface ICityService
    {
        Task<ApiResult<AddCityResponse>> AddCity(AddCityCommand request);
        Task<ApiResult<List<GetCityResponse>>> GetCity();
    }
}
