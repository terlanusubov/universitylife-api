using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniveristyLifeApp.Models.v1.Cities.UpdateCity
{
    public class UpdateCityResponse
    {
        public string Name { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int CountryId { get; set; }
        public int CityStatusId { get; set; }
        public bool IsTop { get; set; }
    }
}
