using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniveristyLifeApp.Models.v1.UserWishlist.CreateUserWishlist
{
    public class CreateUserWishlistRequest
    {
        public int UserId { get; set; }
        public int BedRoomId { get; set; }
    }
}
