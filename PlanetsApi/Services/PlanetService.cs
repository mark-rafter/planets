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
        Task<Planet> Get(string name);
        Task<IEnumerable<string>> GetPlanetNames();
    }

    public class PlanetService : IPlanetService
    {
        readonly string planetsJsonPath;

        public PlanetService(IWebHostEnvironment env)
        {
            planetsJsonPath = env.ContentRootPath + Path.DirectorySeparatorChar
                + "Data" + Path.DirectorySeparatorChar + "planets.json";
        }

        public async Task<Planet> Get(string name)
        {
            var planets = await GetAll();
            return planets.Single(p => p.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
        }

        async Task<IEnumerable<Planet>> GetAll()
        {
            using FileStream fs = File.OpenRead(planetsJsonPath);
            return await JsonSerializer.DeserializeAsync<IEnumerable<Planet>>(fs)
                ?? throw new InvalidOperationException($"No planets found in {planetsJsonPath}");
        }

        public async Task<IEnumerable<string>> GetPlanetNames()
        {
            var planets = await GetAll();
            return planets.Select(p => p.Name);
        }
    }
}