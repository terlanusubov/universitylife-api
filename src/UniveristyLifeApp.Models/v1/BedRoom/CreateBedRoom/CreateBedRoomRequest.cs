using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniveristyLifeApp.Models.v1.BedRoom.CreateBedRoom
{
    public class CreateBedRoomRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int Rating { get; set; }
        public float DistanceToCenter { get; set; }

        //Bedroom image
        //public string Image { get; set; }
        //public bool IsMain { get; set; }
        //public bool IsActive { get; set; }
        public List<IFormFile> ImageFile { get; set; }

        //City
        public int CityId { get; set; }
    }
}
