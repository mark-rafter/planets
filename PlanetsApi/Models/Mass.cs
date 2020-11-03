namespace PlanetsApi.Models
{
    public class Mass
    {
        readonly decimal massInKg;

        public Mass(decimal massInKg)
        {
            this.massInKg = massInKg;
        }

        public string Kg => massInKg.ToString("E");
        public string Lbs => (massInKg * 2.204623m).ToString("E");
        public string Earths => string.Format("{0:#,##0.##}", massInKg / 5.97237e24m);
    }
}