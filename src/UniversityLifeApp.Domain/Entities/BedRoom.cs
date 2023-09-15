using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLifeApp.Domain.Entities
{
    public class BedRoom:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int Rating { get; set; }
        public float DistanceToCenter { get; set; }
        public int BedRoomStatusId { get; set; }
        public decimal Price { get; set; }

        //City
        public int CityId { get; set; }
        public City City { get; set; }

        //Bedroom types
        public ICollection<BedRoomRoomType> BedRoomRoomTypes { get; set; }

        //Bedroomrooms
        public ICollection<BedRoomRoom> BedRoomRooms { get; set; }

        //Bedroom photos
        public ICollection<BedRoomPhoto> BedRoomPhotos { get; set; }

        //User wishlist
        public ICollection<UserWishlist> UserWishLists { get; set; }
    }
}
