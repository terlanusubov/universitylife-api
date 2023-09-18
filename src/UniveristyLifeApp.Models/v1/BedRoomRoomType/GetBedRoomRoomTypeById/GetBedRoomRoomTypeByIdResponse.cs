using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniveristyLifeApp.Models.v1.BedRoomRoomType.GetBedRoomRoomTypeById
{
    public class GetBedRoomRoomTypeByIdResponse
    {
        public int BedRoomRoomTypeStatusId { get; set; }
        public string Name { get; set; }

        //Bedroom
        public int BedRoomId { get; set; }
    }
}
