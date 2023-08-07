using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Countries.AddCountry;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.CQRS.v1.Countryies.Commands.AddCountry;

namespace UniversityLifeApp.Application.Interfaces
{
    public interface ICountryService
    {
        Task<ApiResult<AddCountryResponse>> AddCountry(AddCountryCommand request);
    }
}
