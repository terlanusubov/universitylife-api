using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniveristyLifeApp.Models.v1.OurService.CreateOurService
{
    public class CreateOurServiceRequest
    {
        public IFormFile ImageFile { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
