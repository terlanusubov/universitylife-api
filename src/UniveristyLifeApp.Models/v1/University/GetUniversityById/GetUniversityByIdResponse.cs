using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniveristyLifeApp.Models.v1.University.GetUniversityById
{
    public class GetUniversityByIdResponse
    {
        public int UniversityId { get; set; }
        public string Name { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int UniversityStatusId { get; set; }

        //City
        public int CityId { get; set; }
    }
}
