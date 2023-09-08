using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLifeApp.Domain.Entities
{
    public class BedRoomRoomApply:BaseEntity
    {
        //public string Applied { get; set; }
        public int BedRoomRoomApplyStatusId { get; set; }

        //Bedroomroom
        public int BedRoomRoomId { get; set; }
        public BedRoomRoom BedRoomRoom { get; set; }

        //User
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
