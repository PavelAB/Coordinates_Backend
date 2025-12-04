using Coordiantes_Tools.Queries;
using Coordinates_CQS_Domain.Entities.Spot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coordinates_CQS_Domain.Queries.Spot
{
    public class GetSpotLight: IQueryDefinition<List<Spot_Light>>
    {
        public Guid? IdSpot { get; }
        public decimal? Longitude { get; }
        public decimal? Latitude { get; }
        public string? Name { get; }
        public Guid? CreatedBy { get; }
        public bool? IsPrivate { get; }
        public GetSpotLight(
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
