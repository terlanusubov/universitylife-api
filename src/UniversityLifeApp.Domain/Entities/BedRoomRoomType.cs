using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLifeApp.Domain.Entities
{
    public class BedRoomRoomType:BaseEntity
    {
        public string Name { get; set; }

        //Bedroom
        public int BedRoomId { get; set; }
        public BedRoom BedRoom { get; set; }

        //Bedroomrooms
        public ICollection<BedRoomRoom> BedRoomRooms { get; set; }
    }
}
