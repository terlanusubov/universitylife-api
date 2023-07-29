using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Account.Register;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.Account.Commands.Register
{
    public class RegisterCommand:IRequest<ApiResult<RegisterResponse>>
    {
        public RegisterCommand(RegisterRequest request)
        {
            RegisterReguest = request;
        }

        public RegisterRequest RegisterReguest { get; set; }
    }
}
