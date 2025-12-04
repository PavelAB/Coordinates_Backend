using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coordinates_CQS_Domain.Entities.Track
{
    public class Track_Get
    {
        public Guid IdTrack { get; set; }
        public decimal Distance { get; set; }
        public decimal Ascent { get; set; }
        public decimal Descent { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public bool IsPrivate { get; set; }
        public string PolyLine { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; } = null;
        public DateTime? DeletedAt { get; set; } = null;
        public Guid CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; } = null;
        public Guid? DeletedBy { get; set; } = null;
        public List<Surface.Surface> Surfaces { get; set; } = [];
        public List<EntityType.EntityType> EntityTypes { get; set; } = [];
    }
}
