namespace Coordinates_API.Dtos.Spot
{
    public class SpotCreate
    {

        public decimal Latitude { get; }
        public decimal Longitude { get; }
        public decimal Elevation { get; }
        public string? Name { get; }
        public Guid? EntityType { get; }
        public Guid? SurfaceType { get; }
        public Guid CreatedBy { get; }
        public SpotCreate(
            decimal latitude, 
            decimal longitude, 
            decimal elevation, 
            Guid createdBy,
            string? name, 
            Guid? entityType, 
            Guid? surfaceType)
        {
            Latitude = latitude;
            Longitude = longitude;
            Elevation = elevation;
            Name = name;
            EntityType = entityType;
            SurfaceType = surfaceType;
            CreatedBy = createdBy;
        }



    }
}
