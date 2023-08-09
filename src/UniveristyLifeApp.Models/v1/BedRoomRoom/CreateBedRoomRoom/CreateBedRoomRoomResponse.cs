using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniveristyLifeApp.Models.v1.BedRoomRoom.CreateCity
{
    public class CreateBedRoomRoomResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int BedRoomId { get; set; }
        public int BedRoomRoomTypeId { get; set; }
    }
}
