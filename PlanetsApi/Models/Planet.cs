namespace PlanetsApi.Models
{
    public record Planet(
        string Name,
        string ImageUrl,
        string DistanceFromSun,
        string Mass,
        Length Diameter)
    {
        public Planet(PlanetEntity entity)
        : this(entity.Name, entity.ImageUrl, entity.DistanceFromSun, entity.Mass, new Length(entity.DiameterInKm))
        {
        }
    }

    public record PlanetEntity(
        string Name,
        string ImageUrl,
        string DistanceFromSun,
        string Mass,
        decimal DiameterInKm);

    public class Length
    {
        readonly decimal diameterInKm;

        public Length(decimal diameterInKm)
        {
            this.diameterInKm = diameterInKm;
        }

        public string Km => diameterInKm.ToString("N0");
        public string Miles => (diameterInKm * 0.62137m).ToString("N0");
        public string Earths => string.Format("{0:#,##0.##}", diameterInKm / 12_742);
    }
}