using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLifeApp.Domain.Entities
{
    public class Logs:BaseEntity
    {
        public string Text { get; set; }
        public int LogType { get; set; }
        public string IPAddress { get; set; }
        
    }
}
