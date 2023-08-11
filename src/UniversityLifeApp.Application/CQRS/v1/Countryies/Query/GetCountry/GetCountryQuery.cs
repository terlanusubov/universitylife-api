using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Countries.GetCountry;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.Countryies.Query.GetCountry
{
    public class GetCountryQuery:IRequest<ApiResult<List<GetCountryResponse>>>
    {
        public string Name { get; set; }
        public int CountryStatisId { get; set; }
        public ICollection<string> CiytEs { get; set; }
    }
}
