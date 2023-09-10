using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniveristyLifeApp.Models.v1.Counter.GetCounter
{
    public class GetCounterResponse
    {
        public int StudentCount { get; set; }
        public int CityCount { get; set; }
        public int BedRoomCount { get; set; }
        public int UniversityCount { get; set; }
    }
}
