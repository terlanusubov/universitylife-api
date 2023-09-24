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
        public int BedRoomRoomTypeStatusId { get; set; }

        //Bedroom
        //public int BedRoomId { get; set; }
        //public BedRoom BedRoom { get; set; }

        public ICollection<RoomType> RoomTypes { get; set; }

        //Bedroomrooms
        //public ICollection<BedRoomRoom> BedRoomRooms { get; set; }
    }
}