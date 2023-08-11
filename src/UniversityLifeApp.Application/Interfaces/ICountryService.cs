using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Countries.AddCountry;
using UniveristyLifeApp.Models.v1.Countries.DeleteCountry;
using UniveristyLifeApp.Models.v1.Countries.GetCountry;
using UniveristyLifeApp.Models.v1.Countries.UpdateCountrt;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.CQRS.v1.Countryies.Commands.AddCountry;
using UniversityLifeApp.Application.CQRS.v1.Countryies.Commands.UpdateCountry;

namespace UniversityLifeApp.Application.Interfaces
{
    public interface ICountryService
    {
        Task<ApiResult<AddCountryResponse>> AddCountry(AddCountryCommand request);
        Task<ApiResult<List<GetCountryResponse>>> GetCountry();
        Task<ApiResult<UpdateCountryResponse>> UpdateCountry(UpdateCountryCommand request, int countryId);
        Task<ApiResult<DeleteCountryResponse>> DeleteCountry(int countryId);

    }
}
