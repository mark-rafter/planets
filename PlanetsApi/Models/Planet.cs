namespace PlanetsApi.Models
{
    public record Planet(
        string Name,
        string ImageUrl,
        string DistanceFromSun,
        string Mass,
        Diameter Diameter)
    {
        public Planet(PlanetEntity entity)
        : this(entity.Name, entity.ImageUrl, entity.DistanceFromSun, entity.Mass, new Diameter(entity.DiameterInKm))
        {
        }
    }

    public record PlanetEntity(
        string Name,
        string ImageUrl,
        string DistanceFromSun,
        string Mass,
        decimal DiameterInKm);

    public record Diameter(decimal Km)
    {
        public decimal Miles => Km * 0.62137m;
        public decimal Earths => Km / 12_756;
    }
}