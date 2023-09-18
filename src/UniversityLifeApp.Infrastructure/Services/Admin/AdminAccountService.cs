using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Admin.Login;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces.Admin;
using UniversityLifeApp.Domain.Enums;
using UniversityLifeApp.Infrastructure.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.AspNetCore.Http;

namespace UniversityLifeApp.Infrastructure.Services.Admin
{
    public class AdminAccountService : IAdminAccountService
    {
        private readonly ApplicationContext _context;
        private readonly HttpContext _httpContext;
        public AdminAccountService(ApplicationContext context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext.HttpContext;
        }
        public async Task<ApiResult<LoginResponse>> Login(LoginRequest request)
        {
            var admin = await _context.Users.Where(x => x.Email == request.Email).FirstOrDefaultAsync();

            if (admin == null)
            {
                Dictionary<string, string> errorList = new Dictionary<string, string>();

                errorList.Add("Email", "Email is incorrect");
                return ApiResult<LoginResponse>.Error(ErrorCodes.EMAIL_OR_PASSWORD_IS_NOT_CORRECT, errorList);
            }

            bool check = admin.CheckPassword(request.Password);

            if (!check)
            {
                Dictionary<string, string> errorList = new Dictionary<string, string>();

                errorList.Add("Password", "Password is incorrect");
                return ApiResult<LoginResponse>.Error(ErrorCodes.PASSWORD_IS_INCORRECT, errorList);
            }

            var claims = new List<Claim>
                {
                new Claim("Email", admin.Email),
                new Claim("Name", admin.Name),
                new Claim("Id",admin.Id.ToString()),
                new Claim("RoleId",admin.UserRoleId.ToString()),
                new Claim(ClaimTypes.Role, "Admin")
                };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1),
            };

            await _httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity), authProperties);

            _httpContext.Session.Remove("loginRequest");

            LoginResponse response = new LoginResponse
            {
                Email = admin.Email,
                Name = admin.Name,
                Surname = admin.Surname,

            };

            return ApiResult<LoginResponse>.OK(response);
        }
    }
}