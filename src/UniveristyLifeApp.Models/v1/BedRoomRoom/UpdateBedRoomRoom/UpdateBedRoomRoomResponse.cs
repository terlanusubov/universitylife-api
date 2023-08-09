using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniveristyLifeApp.Models.v1.BedRoomRoom.UpdateBedRoomRoom
{
    public class UpdateBedRoomRoomResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int BedRoomId { get; set; }
        public int BedRoomRoomTypeId { get; set; }
        public int BedRoomRoomStatusId { get; set; }
    }
}
