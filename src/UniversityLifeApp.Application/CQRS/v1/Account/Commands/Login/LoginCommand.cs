using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Account.Login;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.Account.Commands.Login
{
    public class LoginCommand:IRequest<ApiResult<LoginResponse>>
    {
        public LoginCommand(LoginRequest request)
        {
            LoginRequest = request;
        }

        public LoginRequest LoginRequest { get; set; }
    }
}
