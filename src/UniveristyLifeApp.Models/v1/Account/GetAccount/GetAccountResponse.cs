using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniveristyLifeApp.Models.v1.Account.GetAccount
{
    public class GetAccountResponse
    {
        public string Name { get; set; }
        public string SureName { get; set; }
        public string Email { get; set; }
        public string PhoneNumebr { get; set; }
        public int UserRoleId { get; set; }
    }
}
