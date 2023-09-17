using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniveristyLifeApp.Models.v1.BookBedRoomRoom.GetBookBedRoomRoom
{
    public class GetBookBedRoomRoomResponse
    {
        public int Id { get; set; }
        public string BedRoomRoomName { get; set; }
        public string Fullname { get; set; }
        public float Price { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string BedRoomRoomType { get; set; }
        public string BedRoomName { get; set; }
        public string Image { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public int BedRoomRoomApplyStatusId { get; set; }

    }
}
