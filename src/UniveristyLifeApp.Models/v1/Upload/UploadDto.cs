using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniveristyLifeApp.Models.v1.Upload
{
    public class UploadDto
    {
        public byte[]? Data { get; set; }
        public IFormFile File { get; set; }
        public string FileName { get; set; }
    }
}
