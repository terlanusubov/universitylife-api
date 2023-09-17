using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Admin.Login;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces.Admin;

namespace UniversityLifeApp.Application.CQRS.v1.Admin.Account.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, ApiResult<LoginResponse>>
    {
        private readonly IAdminAccountService _accountService;
        public LoginCommandHandler(IAdminAccountService accountService)
        {
                _accountService = accountService;
        }
        public async Task<ApiResult<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var result = await _accountService.Login(request.Request);

            return result;
        }
    }
}
