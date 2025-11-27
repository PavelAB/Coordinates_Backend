using Coordinates_CQS_Domain.Entities.Surface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coordinates_CQS_Domain.Entities.Spot
{
    public class Spot_Get
    {

        public Guid IdSpot { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public decimal Elevation { get; set; }
        public string Name { get; set; }
        public bool IsPrivate { get; set; } = false;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; } = null;
        public DateTime? DeletedAt { get; set; } = null;
        public Guid CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; } = null;
        public Guid? DeletedBy { get; set; } = null;
        public List<Surface.Surface> Surfaces { get; set; } = [];
        

    }
}
