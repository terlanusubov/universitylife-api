﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniveristyLifeApp.Models.v1.Upload
{
    public class UploadRequest
    {
        public List<UploadDto> UploadDto { get; set; }
        public string Folder { get; set; }
    }
}
