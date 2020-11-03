namespace PlanetsApi.Models
{
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