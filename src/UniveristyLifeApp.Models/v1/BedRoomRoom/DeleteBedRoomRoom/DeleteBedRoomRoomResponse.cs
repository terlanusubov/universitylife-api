using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniveristyLifeApp.Models.v1.BedRoomRoom.DeleteBedRoomRoom
{
    public class DeleteBedRoomRoomResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int BedRoomRoomStatusId { get; set; }

        //Bedroom
        public int BedRoomId { get; set; }

        //Bedroomroom type
        //public int BedRoomRoomTypeId { get; set; }
    }
}
