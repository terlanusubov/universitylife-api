using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Account.GetAccount;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.Account.Query.GetAccount
{
    public class GetAccountQueryHandler : IRequestHandler<GetAccountQuery, ApiResult<List<GetAccountResponse>>>
    {
        private readonly IAccountService _accountService;

        public GetAccountQueryHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public Task<ApiResult<List<GetAccountResponse>>> Handle(GetAccountQuery request, CancellationToken cancellationToken)
        {
            var result = _accountService.GetAccount();
            return result;
        }
    }
}
