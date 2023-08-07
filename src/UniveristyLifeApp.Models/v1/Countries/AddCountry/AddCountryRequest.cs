using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniveristyLifeApp.Models.v1.Countries.AddCountry
{
    public class AddCountryRequest
    {
        public string Name { get; set; }
        public int CountryStatisId { get; set; }
        public ICollection<string> CiytEs { get; set; }
    }
}
