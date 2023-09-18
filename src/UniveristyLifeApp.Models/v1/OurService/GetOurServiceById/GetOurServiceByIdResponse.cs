using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniveristyLifeApp.Models.v1.OurService.GetOurServiceById
{
    public class GetOurServiceByIdResponse
    {
        public int Id { get; set; }
        public int OurServiceStatusId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
