using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLifeApp.Domain.Entities
{
    public class BedRoomRoomPhoto:BaseEntity
    {
        public string Name { get; set; }
        public bool IsMain { get; set; }
        public bool IsActive { get; set; }

        //Bedroomroom
        public int BedRoomRoomId { get; set; }
        public BedRoomRoom BedRoomRoom { get; set; }
    }
}
