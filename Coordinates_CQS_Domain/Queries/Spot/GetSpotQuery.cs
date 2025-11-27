using Coordiantes_Tools.Queries;
using S = Coordinates_CQS_Domain.Entities.Spot; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coordinates_CQS_Domain.Entities.Spot;

namespace Coordinates_CQS_Domain.Queries.Spot
{
    public class GetSpotQuery : IQueryDefinition<S.Spot_Get>
    {
        public Guid? IdSpot { get; }
        public decimal? Longitude { get; } = null;
        public decimal? Latitude { get; } = null;
        public string? Name { get; } = null;
        public Guid? CreatedBy { get; } = null;
        public bool? IsPrivate { get; } = null;
        public GetSpotQuery(
             Guid? idSpot = null, 
             decimal? longitude = null, 
             decimal? latitude = null,
             string? name = null, 
             Guid? createdBy = null, 
             bool? isPrivate = null)
        {
            IdSpot = idSpot;
            Longitude = longitude;
            Latitude = latitude;
            Name = name;
            CreatedBy = createdBy;
            IsPrivate = isPrivate;
        }
    }
}
