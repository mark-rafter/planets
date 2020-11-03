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
    public interface IDataContext
    {
        ValueTask<IReadOnlyList<PlanetEntity>> GetPlanets();
    }

    public class DataContext : IDataContext
    {
        readonly string planetsJsonPath;

        IReadOnlyList<PlanetEntity>? PlanetCollection { get; set; }

        public DataContext(IWebHostEnvironment env)
        {
            planetsJsonPath = env.ContentRootPath + Path.DirectorySeparatorChar
                + "Data" + Path.DirectorySeparatorChar + "planets.json";
        }

        public async ValueTask<IReadOnlyList<PlanetEntity>> GetPlanets()
        {
            if (PlanetCollection is null)
            {
                using FileStream fs = File.OpenRead(planetsJsonPath);

                var planetData = await JsonSerializer.DeserializeAsync<IEnumerable<PlanetEntity>>(fs)
                    ?? throw new InvalidOperationException($"No planets found in {planetsJsonPath}");

                PlanetCollection = planetData.ToList();
            }

            return PlanetCollection;
        }
    }
}