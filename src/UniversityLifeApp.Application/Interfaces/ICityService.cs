using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Cities.AddCity;
using UniveristyLifeApp.Models.v1.Cities.DeleteCity;
using UniveristyLifeApp.Models.v1.Cities.GetCity;
using UniveristyLifeApp.Models.v1.Cities.GetCityById;
using UniveristyLifeApp.Models.v1.Cities.UpdateCity;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.CQRS.v1.Cities.Commands.AddCity;
using UniversityLifeApp.Application.CQRS.v1.Cities.Commands.UpdateCity;

namespace UniversityLifeApp.Application.Interfaces
{
    public interface ICityService
    {
        Task<ApiResult<AddCityResponse>> AddCity(AddCityCommand request);
        Task<ApiResult<List<GetCityResponse>>> GetCity();
        Task<ApiResult<GetCityByIdResponse>> GetCityById(int cityId);
        Task<ApiResult<UpdateCityResponse>> UpdateCity(UpdateCityCommand request, int cityId);
        Task<ApiResult<DeleteCityResponse>> DeleteCity(int cityId);
    }
}
