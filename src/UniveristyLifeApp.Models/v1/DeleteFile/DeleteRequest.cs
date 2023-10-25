using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniveristyLifeApp.Models.v1.DeleteFile
{
    public class DeleteRequest
    {
        public List<DeleteDto> DeleteDto { get; set; }
        public string Folder { get; set; }
    }
}
