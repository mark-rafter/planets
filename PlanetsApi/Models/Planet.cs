namespace PlanetsApi.Models
{
    public record Planet(
        string Name,
        string ImageUrl,
        string DistanceFromSun,
        Mass Mass,
        Length Diameter)
    {
        public Planet(PlanetEntity entity)
        : this(
            entity.Name,
            entity.ImageUrl,
            entity.DistanceFromSunInAu.ToString(),
            new Mass(entity.MassInKg),
            new Length(entity.DiameterInKm))
        {
        }
    }

    public record PlanetEntity(
        string Name,
        string ImageUrl,
        DistanceFromSun DistanceFromSunInAu,
        decimal MassInKg,
        decimal DiameterInKm);

    public record DistanceFromSun(decimal Min, decimal Max)
    {
        public override string ToString() => $"{Min:N2} AU – {Max:N2} AU";
    }
}