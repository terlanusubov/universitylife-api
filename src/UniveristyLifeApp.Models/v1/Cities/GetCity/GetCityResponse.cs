﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniveristyLifeApp.Models.v1.Cities.GetCity
{
    public class GetCityResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public int BedRoomCount { get; set; }
        public string Image { get; set; }
        public bool IsTop { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
