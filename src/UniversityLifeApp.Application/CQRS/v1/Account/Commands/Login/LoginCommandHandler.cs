using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Account.Login;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.Account.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, ApiResult<LoginResponse>>
    {
        private readonly IAccountService _accoutService;
        public LoginCommandHandler(IAccountService accountService)
        {
            _accoutService = accountService;
        }
        public async Task<ApiResult<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
            => await _accoutService.Login(request.LoginRequest);
    }
}
