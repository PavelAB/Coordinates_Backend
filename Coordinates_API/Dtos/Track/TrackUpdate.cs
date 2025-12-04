namespace Coordinates_API.Dtos.Track
{
    public class TrackUpdate
    {
        public Guid IdTrack { get; set; }
        public Guid UpdatedBy { get; set; }
        public decimal? Distance { get; set; }
        public decimal? Ascent { get; set; }
        public decimal? Descent { get; set; }
        public string? Name { get; set; }
        public bool? IsPrivate { get; set; }
        public string? PolyLine { get; set; }
        public TrackUpdate(
            Guid idTrack,
            Guid updatedBy,
            decimal? distance,
            decimal? ascent,
            decimal? descent,
            string? name,
            bool? isPrivate,
            string? polyLine)
        {
            IdTrack = idTrack;
            UpdatedBy = updatedBy;
            Distance = distance;
            Ascent = ascent;
            Descent = descent;
            Name = name;
            IsPrivate = isPrivate;
            PolyLine = polyLine;
        }
    }
}
