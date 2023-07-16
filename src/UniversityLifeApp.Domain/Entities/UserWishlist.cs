using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLifeApp.Domain.Entities
{
    public class UserWishlist:BaseEntity
    {
        //User
        public int UserId { get; set; }
        public User User { get; set; }

        //Bedroom
        public int BedRoomId { get; set; }
        public BedRoom BedRoom { get; set; }
    }
}
