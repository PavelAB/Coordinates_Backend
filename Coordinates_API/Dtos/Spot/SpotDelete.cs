namespace Coordinates_API.Dtos.Spot
{
    public class SpotDelete
    {
        public SpotDelete(Guid idSpot, Guid deletedBy)
        {
            IdSpot = idSpot;
            DeletedBy = deletedBy;
        }

        public Guid IdSpot {  get; set; }
        public Guid DeletedBy { get; set; }
    }
}
