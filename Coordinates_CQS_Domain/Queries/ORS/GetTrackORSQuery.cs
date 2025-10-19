using Coordiantes_Tools.Queries;
using Coordinates_CQS_Domain.Entities.Track;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coordinates_CQS_Domain.Queries.ORS
{
    public class GetTrackORSQuery : IQueryDefinition<TrackCreate>
    {

        public IReadOnlyList<(decimal Longitude, decimal Latitude)> Coordinates { get;}
        public string Key { get; } // ??
       
        public GetTrackORSQuery(IReadOnlyList<(decimal, decimal)> coordinates, string key)
        {
            Coordinates = coordinates;
            Key = key;
        }
        
    }
}
