using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coordinates_CQS_Domain.Entities.Surface
{
    public class Surface
    {

        Guid IdSurface { get; set; }
        string SurfaceType { get; set; }
        public Surface(Guid idSurface, string surfaceType)
        {
            IdSurface = idSurface;
            SurfaceType = surfaceType;
        }
    }
}
