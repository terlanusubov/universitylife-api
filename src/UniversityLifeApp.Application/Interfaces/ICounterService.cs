using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Counter.GetCounter;
using UniveristyLifeApp.Models.v1.Countries.GetCountry;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.Interfaces
{
    public interface ICounterService
    {
        Task<ApiResult<GetCounterResponse>> GetCounter();
    }
}
