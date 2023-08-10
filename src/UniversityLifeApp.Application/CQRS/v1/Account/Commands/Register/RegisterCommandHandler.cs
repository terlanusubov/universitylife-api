using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Account.Register;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.Account.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ApiResult<RegisterResponse>>
    {
        private readonly IAccountService _accountService;
        public RegisterCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public async Task<ApiResult<RegisterResponse>> Handle(RegisterCommand request, CancellationToken cancellationToken)
            => await _accountService.Register(request.RegisterReguest);

          
    }
}
