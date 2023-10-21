using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLifeApp.Domain.Entities
{
    public class RoomType : BaseEntity
    {
        public int BedRoomId { get; set; }
        public int BedRoomRoomTypeId { get; set; }

        public BedRoom BedRoom { get; set; }
        public BedRoomRoomType BedRoomRoomType { get; set; }

        public ICollection<BedRoomRoom> BedRoomRooms { get; set; }
    }
}