using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Account.Update;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.Account.Commands.Update
{
    public class UpdateCommandHandler : IRequestHandler<UpdateCommand, ApiResult<UpdateResponse>>
    {
        private readonly IAccountService _accountservice;
        public UpdateCommandHandler(IAccountService accountService)
        {
            _accountservice = accountService;
        }
        public async Task<ApiResult<UpdateResponse>> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            var result = await _accountservice.Update(request);

            return result;
        }
    }
}
