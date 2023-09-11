using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniveristyLifeApp.Models.v1.BedRoom.UpdateBedRoom
{
    public class UpdateBedRoomRequest
    {
        //public int BedRoomStatusId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int Rating { get; set; }
        public float DistanceToCenter { get; set; }

        //Bedroom image
        public List<IFormFile> ImageFile { get; set; }

        //City
        public int CityId { get; set; }
    }
}
