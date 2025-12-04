namespace Coordinates_API.Dtos.Spot
{
    public class SpotUpdate
    {
        public SpotUpdate(Guid idSpot, decimal latitude, decimal longitude, decimal elevation, bool isPrivate, string name, Guid updatedBy)
        {
            IdSpot = idSpot;
            Latitude = latitude;
            Longitude = longitude;
            Elevation = elevation;
            IsPrivate = isPrivate;
            Name = name;
            UpdatedBy = updatedBy;
        }

        public Guid IdSpot { get; }
        public decimal Latitude { get; }
        public decimal Longitude { get; }
        public decimal Elevation { get; }
        public bool IsPrivate { get; }
        public string Name { get; }
        public Guid UpdatedBy { get; }
        
    }
}
