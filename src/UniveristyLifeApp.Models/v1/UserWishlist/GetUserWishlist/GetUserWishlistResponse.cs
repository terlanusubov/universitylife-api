using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniveristyLifeApp.Models.v1.UserWishlist.GetUserWishlist
{
    public class GetUserWishlistResponse
    {
        public int BedRoomId { get; set; }
        public int UserId { get; set; }
        public int UserWishlistId { get; set; }
    }
}
