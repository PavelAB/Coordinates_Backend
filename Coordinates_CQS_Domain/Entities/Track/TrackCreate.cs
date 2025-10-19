using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coordinates_CQS_Domain.Entities.Track
{
    public class TrackCreate
    {
        public decimal Distance {  get; set; }
        public decimal Elevation { get; set; }
        public string PolyLine { get; set; }
    }
}
