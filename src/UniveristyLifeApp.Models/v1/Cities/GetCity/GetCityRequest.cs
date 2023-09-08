using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniveristyLifeApp.Models.v1.Cities.GetCity
{
    public class GetCityRequest
    {
        public bool? IsTop { get; set; }
        public int? CountryId { get; set; }
    }
}
