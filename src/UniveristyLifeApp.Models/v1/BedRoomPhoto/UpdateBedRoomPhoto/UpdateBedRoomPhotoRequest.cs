using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniveristyLifeApp.Models.v1.BedRoomPhoto.UpdateBedRoomPhoto
{
    public class UpdateBedRoomPhotoRequest
    {
        public int Id { get; set; }
        public bool IsMain { get; set; }
        public bool IsActive { get; set; }

        //Bedroom
        public int BedroomId { get; set; }
    }
}
