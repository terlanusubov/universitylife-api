using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLifeApp.Domain.Entities
{
    public class OurService : BaseEntity
    {
        public string Image { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public int OurServiceStatusId { set; get; }
    }
}
