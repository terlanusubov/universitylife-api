using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Account.GetAccount;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.Account.Query.GetAccount
{
    public class GetAccountQuery:IRequest<ApiResult<List<GetAccountResponse>>>
    {
        public string Name { get; set; }
        public string SureName { get; set; }
        public string Email { get; set; }
        public string PhoneNumebr { get; set; }
        public string UserRoleId { get; set; }
    }
}
