using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLifeApp.Domain.Entities
{
    public class Country:BaseEntity
    {
        public string Name { get; set; }
        public int CountryStatusId { get; set; }

        //Cities
        public ICollection<City> Cities { get; set; }
    }
}
