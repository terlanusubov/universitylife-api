using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using UniveristyLifeApp.Models.v1.Admin.Login;
using UniversityLifeApp.Application.CQRS.v1.Admin.Account.Commands.Login;
using UniversityLifeApp.Domain.Entities;
using UniversityLifeApp.Infrastructure.Data;

namespace UniversityLifeApp.MVC.Controllers
{
    //[Area("admin")]
    public class AccountController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ApplicationContext _context;
        public AccountController(IMediator mediator, ApplicationContext context)
        {
            _context = context;
            _mediator = mediator;
        }
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var result = await _mediator.Send(new LoginCommand(request));

            if (result.StatusCode != (int)HttpStatusCode.OK)
            {
                foreach (var item in result.ErrorList)
                {
                    ModelState.AddModelError(item.Key , item.Value);
                }

                return View(request);
            }

            return RedirectToAction("index", "home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("login", "Account");
        }

       public async Task<IActionResult> Create()
        {
            User admin = new User
            {
                Name = "Ibrahim",
                Surname = "Ahmedzade",
                Email = "axmedovibrahim0004@gmail.com",
                PhoneNumber = "+994505008028",
                UserRoleId = 20,
                UserStatusId = 10,
                
            };

            admin.AddPassword("Ibrahim12345678");

            await _context.AddAsync(admin);
            await _context.SaveChangesAsync();

            return Ok(admin);
        }
    }
}
