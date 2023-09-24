using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniveristyLifeApp.Models.v1.BedRoomRoomType.GetBedRoomRoomType
{
    public class GetBedRoomRoomTypeResponse
    {
        public int Id { get; set; }
        public int BedRoomRoomTypeStatusId { get; set; }
        public string Name { get; set; }
        //public string BedRoomName { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }

        //Bedroom
        //public int BedRoomId { get; set; }
    }
}
