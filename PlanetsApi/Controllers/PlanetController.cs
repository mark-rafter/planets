using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlanetsApi.Models;
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
        public async Task<IEnumerable<Planet>> Get()
        {
            return await planetService.GetAll();
        }

        [HttpGet("{name}")]
        public async Task<IEnumerable<Planet>> Get(string name)
        {
            throw new NotImplementedException();
        }
    }
}
