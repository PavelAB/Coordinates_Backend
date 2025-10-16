using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coordinates_CQS_Domain.Entities.Spot
{
    public class DTO_Spot_Create
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public decimal Elevation { get; set; }
        public string? Name { get; set; }
        public Guid EntityType { get; set; }
        public Guid SurfaceType { get; set; }
        public Guid CreatedBy { get; set; }

    }
}
