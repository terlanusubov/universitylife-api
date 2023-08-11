using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLifeApp.Domain.Entities
{
    public class University:BaseEntity
    {
        public string Name { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int UniversityStatusId { get; set; }

        //City
        public int CityId { get; set; }
        public City City { get; set; }
    }
}
