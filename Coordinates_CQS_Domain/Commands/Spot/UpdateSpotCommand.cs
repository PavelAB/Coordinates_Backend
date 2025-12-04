using Coordiantes_Tools.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coordinates_CQS_Domain.Commands.Spot
{
    public class UpdateSpotCommand: ICommandDefinition
    {

        public Guid IdSpot { get; set; }
        public Guid UpdatedBy { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? Elevation { get; set; }
        public bool? IsPrivate { get; set; }
        public string? Name { get; set; }
        public UpdateSpotCommand(Guid idSpot, Guid updatedBy, decimal? latitude, decimal? longitude, decimal? elevation, bool? isPrivate, string? name)
        {
            IdSpot = idSpot;
            UpdatedBy = updatedBy;
            Latitude = latitude;
            Longitude = longitude;
            Elevation = elevation;
            IsPrivate = isPrivate;
            Name = name;
        }
    }
}
