using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniveristyLifeApp.Models.v1.Countries.AddCountry
{
    public class CountryRequest
    {
        public string Name { get; set; }
        public int CountryStatusId { get; set; }

        public ICollection<string> Cities { get; set; }
    }
}
