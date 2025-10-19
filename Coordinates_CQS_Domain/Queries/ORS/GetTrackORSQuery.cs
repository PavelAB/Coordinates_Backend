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

        public string Start { get; }
        public string End { get; }
        public string Key { get; } // ??
        public GetTrackORSQuery(string start, string end, string key)
        {
            Start = start;
            End = end;
            Key = key;
        }
    }
}
