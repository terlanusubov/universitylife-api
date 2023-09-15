using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityLifeApp.Domain.Entities;

namespace UniveristyLifeApp.Models.v1.BedRoom.GetBedRoom
{
    public class GetBedRoomResponse
    {
        public List<GetBedRoomsDto> BedRooms { get; set; }

        public int TotalPage { get; set; }
        public int TotalData { get; set; }
        public int PageSize { get; set; }
        public List<IDictionary<int,double>> Dictance { get; set; }

        //public List<string> BedRoomImages { get; set; }

    }
}
