using CarService.Infrastructure.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;

using System.Threading.Tasks;

namespace CarService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly ILogger<CarsController> _logger;
        private readonly IDbContextFactory _dbContextFactory;

        public CarsController(ILogger<CarsController> logger, IDbContextFactory dbContextFactory)
        {
            _logger = logger;
            _dbContextFactory = dbContextFactory;
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
           await using var context = _dbContextFactory.GetDefaultDbContext();

            var cars = await context.Cars.ToArrayAsync();

            return Ok(cars);
        }
    }
}
