using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniveristyLifeApp.Models.v1.OurService.CreateOurService
{
    public class CreateOurServiceResponse
    {
        public string Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int OurServiceStatusId { get; set; }
    }
}
