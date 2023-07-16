using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLifeApp.Domain.Entities
{
    public class BedRoomPhoto:BaseEntity
    {
        public string Name { get; set; }
        public bool IsMain { get; set; }
        public bool IsActive { get; set; }

        //Bedroom
        public int BedroomId { get; set; }
        public BedRoom BedRoom { get; set; }
    }
}
