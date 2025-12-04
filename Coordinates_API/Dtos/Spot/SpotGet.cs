namespace Coordinates_API.Dtos.Spot
{
    public class SpotGet
    {

        public decimal Longitude { get; }
        public decimal Latitude { get; }
        public SpotGet(decimal longitude, decimal latitude)
        {
            Longitude = longitude;
            Latitude = latitude;
        }
    }
}
