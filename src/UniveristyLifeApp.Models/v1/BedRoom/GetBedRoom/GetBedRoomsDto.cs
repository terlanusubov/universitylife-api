using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniveristyLifeApp.Models.v1.BedRoom.GetBedRoom
{
    public class GetBedRoomsDto
    {
        public int Id { get; set; }
        public int BedRoomStatusId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int Rating { get; set; }
        public float DistanceToCenter { get; set; }
        public decimal Price { get; set; }
        public double? Distance { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public List<string> BedRoomImages { get; set; }
        public List<string> BedRoomRoomTypes { get; set; }
        public List<int> BedRoomRoomTypeIds { get; set; }


        //City
        public int CityId { get; set; }
    }
}
