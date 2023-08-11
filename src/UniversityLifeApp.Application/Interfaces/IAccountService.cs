using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Account.Login;
using UniveristyLifeApp.Models.v1.Account.Register;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.CQRS.v1.Account.Commands.Register;

namespace UniversityLifeApp.Application.Interfaces
{
    public interface IAccountService
    {
        Task<ApiResult<RegisterResponse>> Register(RegisterRequest request);
        Task<ApiResult<LoginResponse>> Login(LoginRequest request);
    }
}
