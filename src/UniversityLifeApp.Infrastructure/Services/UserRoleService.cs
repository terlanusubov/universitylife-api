using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.UserRole.CreateRole;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.CQRS.v1.UserRole.Commands.CreateUserRole;
using UniversityLifeApp.Application.Interfaces;
using UniversityLifeApp.Domain.Entities;
using UniversityLifeApp.Domain.Enums;
using UniversityLifeApp.Infrastructure.Data;

namespace UniversityLifeApp.Infrastructure.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly ApplicationContext _context;
        public UserRoleService(ApplicationContext context)
            => _context = context;

        public async Task<ApiResult<UserRoleResponse>> Create(CreateUserRoleCommand request)
        {
            UserRole userRole = new UserRole
            {
                Name = request.Request.Name,
                UserRoleStatusId = (int)UserStatusEnum.Active,
            };

            await _context.UserRoles.AddAsync(userRole);
            await _context.SaveChangesAsync();

            UserRoleResponse response = new UserRoleResponse
            {
                Name = userRole.Name,
                UserRoleStatusId = userRole.UserRoleStatusId,
            };

            return ApiResult<UserRoleResponse>.OK(response);
        }
    }
}
