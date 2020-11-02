using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using PlanetsApi.Models;

namespace PlanetsApi.Services
{
    public interface IPlanetService
    {
        Task<IEnumerable<Planet>> GetAll();

        Task<Planet> Get(string name);
    }

    public class PlanetService : IPlanetService
    {
        readonly string planetsJsonPath;

        public PlanetService(IWebHostEnvironment env)
        {
            planetsJsonPath = env.ContentRootPath + Path.DirectorySeparatorChar
                + "Data" + Path.DirectorySeparatorChar + "planets.json";
        }

        public Task<Planet> Get(string name)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Planet>> GetAll()
        {
            using FileStream fs = File.OpenRead(planetsJsonPath);
            return await JsonSerializer.DeserializeAsync<IEnumerable<Planet>>(fs);
        }
    }
}