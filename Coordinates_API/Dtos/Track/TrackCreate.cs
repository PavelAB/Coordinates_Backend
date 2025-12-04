namespace Coordinates_API.Dtos.Track
{
    public class TrackCreate
    {

        public decimal Distance { get; set; }
        public decimal Ascent { get; set; }
        public decimal Descent { get; set; }
        public string Name { get; set; }
        public bool IsPrivate { get; set; }
        public string PolyLine { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid? EntityType { get; set; }
        public Guid? Surface { get; set; }

        public TrackCreate(
            decimal distance, 
            decimal ascent, 
            decimal descent, 
            string name, 
            bool isPrivate, 
            string polyLine, 
            Guid createdBy, 
            Guid? entityType = null, 
            Guid? surface = null
            )
        {
            Distance = distance;
            Ascent = ascent;
            Descent = descent;
            Name = name;
            IsPrivate = isPrivate;
            PolyLine = polyLine;
            CreatedBy = createdBy;
            EntityType = entityType;
            Surface = surface;
        }
    }
}
