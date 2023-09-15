using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniveristyLifeApp.Models.v1.UserWishlist.DeleteUserWishlist
{
    public class DeleteUserWishlistResponse
    {
        public int UserId { get; set; }
        public int BedRoomId { get; set; }
        public int UserWishlistId { get; set; }
    }
}
