using Microsoft.AspNetCore.Mvc;
using Serilog;
using UniveristyLifeApp.Models.v1.Users.AddUser;
using UniversityLifeApp.Application.CQRS.v1.Users.Commands.AddUser;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Infrastructure.Data;
using UniveristyLifeApp.Models.v1.Countries.AddCountry;
using UniversityLifeApp.Application.CQRS.v1.Countries.Commands.CreateCountry;

namespace UniversityLifeApp.API.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]

    public class CountryController : BaseController
    {
        private readonly ApplicationContext _context;

        public CountryController(ApplicationContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult<ApiResult<CountryResponse>>> Get(CountryRequest request)
        {
            Log.Information("salam");
            await Mediator.Send(new CreateCountryCommand(request));
            return Ok();
        }
    }
}
