namespace PlanetsApi.Models
{
    public record Planet(
        string Name,
        string ImageUrl,
        string DistanceFromSun,
        string Mass,
        string Diameter);
}