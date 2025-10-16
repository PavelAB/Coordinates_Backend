using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User = Coordinates_CQS_Domain.Entities.User;

namespace Coordinates_CQS_Domain.Entities.Spot
{
    public class Spot
    {
        public Guid IdSpot { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public decimal Elevation { get; set; }        
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsPrivate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set;}
        public DateTime? DeletedAt { get; set;}
        //public EntityType EntityType { get; set; }
        public Guid EntityType { get; set; }
        //public EntityType SurfaceType { get; set; }
        public Guid SurfaceType { get; set; }
        public User.User CreatedBy { get; set; }
        //public Guid CreatedBy { get; set; }
        public User.User UpdatedBy { get; set; }
        //public Guid? UpdatedBy { get; set; }
        public User.User DeletedBy { get; set; }
        //public Guid? DeletedBy { get; set; }
    }
}
