using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.UserRole.CreateRole;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.CQRS.v1.UserRole.Commands.CreateUserRole;

namespace UniversityLifeApp.Application.Interfaces
{
    public interface IUserRoleService
    {
        Task<ApiResult<UserRoleResponse>> Create(CreateUserRoleCommand request);
    }
}
