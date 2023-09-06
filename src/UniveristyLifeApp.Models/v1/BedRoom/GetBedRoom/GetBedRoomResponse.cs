﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniveristyLifeApp.Models.v1.BedRoom.GetBedRoom
{
    public class GetBedRoomResponse
    {
        public int BedRoomStatusId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int Rating { get; set; }
        public float DistanceToCenter { get; set; }
        public List<string> BedRoomImages { get; set; }

        //City
        public int CityId { get; set; }
    }
}
