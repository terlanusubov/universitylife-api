using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLifeApp.Domain.Entities
{
    public class Counter:BaseEntity
    {
        public int BedRoom { get; set; }
        public int City { get; set; }
        public int Student { get; set; }
        public int University { get; set; }
    }
}
