using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlanetsApi.Services;

namespace PlanetsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlanetController : ControllerBase
    {
        readonly IPlanetService planetService;

        public PlanetController(IPlanetService planetService)
        {
            this.planetService = planetService;
        }

        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            return await planetService.GetPlanetNames();
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var result = await planetService.Get(name);
            return result is null ? NotFound() : Ok(result);
        }
    }
}
