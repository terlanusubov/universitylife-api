﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniveristyLifeApp.Models.v1.BedRoom.GetBedRoom
{
    public class GetBedRoomRequest
    {
        public int? UniversityId { get; set; }
        public int? CityId { get; set; }
        public int? Page { get; set; }
    }
}
