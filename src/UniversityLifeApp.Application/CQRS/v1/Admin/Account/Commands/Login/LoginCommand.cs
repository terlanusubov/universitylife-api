using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Admin.Login;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.Admin.Account.Commands.Login
{
    public class LoginCommand:IRequest<ApiResult<LoginResponse>>
    {
        public LoginCommand(LoginRequest request)
        {
            Request = request;
        }

        public LoginRequest Request { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
    }
}
