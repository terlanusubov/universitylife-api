﻿using Microsoft.AspNetCore.Mvc;
using UniveristyLifeApp.Models.v1.Account.Register;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/account")]
    [ApiVersion("1.0")]
    public class AccountController : BaseController
    {
        //[HttpGet]
        //public async Task<IActionResult> Login()
        //{
        //    return View();
        //}

        //[HttpGet]
        //public async Task<IActionResult> Register()
        //{
        //    return View();
        //}

        [HttpPost("register")]
        public async Task<ActionResult<ApiResult<RegisterResponse>>> Register(RegisterRequest request)
        {

        }
    }
}
