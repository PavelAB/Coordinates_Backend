using Coordiantes_Tools.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coordinates_CQS_Domain.Commands.Spot
{
    public class CreateSpotCommand : ICommandDefinition
    {

        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public decimal Elevation { get; set; }
        public string? Name { get; set; }
        public Guid EntityType { get; set; }
        public Guid SurfaceType { get; set; }
        public Guid CreatedBy { get; set; }
        public CreateSpotCommand(decimal latitude, decimal longitude, decimal elevation, string? name, Guid entityType, Guid surfaceType, Guid createdBy)
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
