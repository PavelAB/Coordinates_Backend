using Coordiantes_Tools.Queries;
using Coordinates_CQS_Domain.Entities.Track;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coordinates_CQS_Domain.Queries.Track
{
    public class GetTrackQuery: IQueryDefinition<List<Track_Get>>
    {

        public Guid? IdTrack { get; set; } = null;
        public decimal? Distance { get; set; } = null;
        public decimal? Ascent { get; set; } = null;
        public decimal? Descent { get; set; } = null;
        public string? Name { get; set; } = null;
        public Guid? CreatedBy { get; set; } = null;
        public GetTrackQuery(
            Guid? idTrack = null, 
            decimal? distance = null, 
            decimal? ascent = null, 
            decimal? descent = null, 
            string? name = null, 
            Guid? createdBy = null)
        {
            IdTrack = idTrack;
            Distance = distance;
            Ascent = ascent;
            Descent = descent;
            Name = name;
            CreatedBy = createdBy;
        }

    }
}
