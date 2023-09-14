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
        public GetBedRoomResponse BedRoom { get; set; }
        public int UserId { get; set; }
        public int UserWishlistId { get; set; }
    }
}
