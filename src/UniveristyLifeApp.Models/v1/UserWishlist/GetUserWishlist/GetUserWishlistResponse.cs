using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BedRoom.GetBedRoom;

namespace UniveristyLifeApp.Models.v1.UserWishlist.GetUserWishlist
{
    public class GetUserWishlistResponse
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
        public List<string> BedRoomImages { get; set; }
        public List<string> BedRoomRoomTypes { get; set; }

        //City
        public int CityId { get; set; }

        public int UserId { get; set; }
        public int UserWishlistId { get; set; }
    }
}