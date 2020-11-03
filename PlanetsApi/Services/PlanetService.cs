using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using PlanetsApi.Models;

namespace PlanetsApi.Services
{
    public interface IPlanetService
    {
        Task<Planet?> Get(string name);
        Task<IEnumerable<string>> GetPlanetNames();
    }

    public class PlanetService : IPlanetService
    {
        readonly IDataContext dataContext;

        public PlanetService(IDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<Planet?> Get(string name)
        {
            var planetEntity = (await dataContext.GetPlanets())
                .SingleOrDefault(p => p.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));

            return planetEntity is not null ? new Planet(planetEntity) : null;
        }

        public async Task<IEnumerable<string>> GetPlanetNames()
        {
            var planetEntities = await dataContext.GetPlanets();
            return planetEntities.Select(p => p.Name);
        }
    }
}