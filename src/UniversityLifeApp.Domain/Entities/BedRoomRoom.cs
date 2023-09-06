using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLifeApp.Domain.Entities
{
    public class BedRoomRoom:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int BedRoomRoomStatusId { get; set; }

        //Bedroom
        public int BedRoomId { get; set; }
        public BedRoom BedRoom { get; set; }

        //Bedroomroom type
        public int BedRoomRoomTypeId { get; set; }
        public BedRoomRoomType BedRoomRoomType { get; set; }

        //Bedroomroom photos
        public ICollection<BedRoomRoomPhoto> BedRoomRoomPhotos { get; set; }

        //Bedroomroom apply
        public ICollection<BedRoomRoomApply> BedRoomRoomApplies { get; set; }
    }
}
