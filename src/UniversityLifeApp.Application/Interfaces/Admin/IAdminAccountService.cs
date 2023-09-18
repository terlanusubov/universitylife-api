using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Admin.Login;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.Interfaces.Admin
{
    public interface IAdminAccountService
    {
        Task<ApiResult<LoginResponse>> Login(LoginRequest request);
    }
}
