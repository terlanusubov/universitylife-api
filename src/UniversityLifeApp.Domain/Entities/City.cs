using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLifeApp.Domain.Entities
{
    public class City:BaseEntity
    {
        public string Name { get; set; }
        public int CityStatusId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public bool IsTop { get; set; }
        public string Image { get; set; }

        //Country
        public int CountryId { get; set; }
        public Country Country { get; set; }

        //Bedrooms
        public ICollection<BedRoom> BedRooms { get; set; }

        //Universities
        public ICollection<University> Universities { get; set; }
    }
}
