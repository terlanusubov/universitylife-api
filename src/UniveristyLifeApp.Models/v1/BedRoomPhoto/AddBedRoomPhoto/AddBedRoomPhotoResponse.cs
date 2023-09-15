using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniveristyLifeApp.Models.v1.BedRoomPhoto.AddBedRoomPhoto
{
    public class AddBedRoomPhotoResponse
    {
        public string Name { get; set; }
        public bool IsMain { get; set; }
        public bool IsActive { get; set; }
        //public IFormFile ImageFile { get; set; }

        //Bedroom
    }
}
