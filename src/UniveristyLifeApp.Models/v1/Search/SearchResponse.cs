﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniveristyLifeApp.Models.v1.Search
{
    public class SearchResponse
    {
        public string Name { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public int SearchId { get; set; }
        
    }
}
