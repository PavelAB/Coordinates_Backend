using Coordiantes_Tools.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coordinates_CQS_Domain.Commands.Track
{
    public class CreateTrackCommand : ICommandDefinition
    {
        public CreateTrackCommand(
            decimal distance, 
            decimal ascent, 
            decimal descent, 
            string polyLine, 
            Guid createdBy, 
            List<Guid> wayPointsId, 
            List<int> wayPointsOrder,
            bool? isPrivate = null, 
            Guid? entityType = null, 
            Guid? surfaceType = null, 
            string? name = null
            )
        {
            Distance = distance;
            Ascent = ascent;
            Descent = descent;
            Name = name;
            IsPrivate = isPrivate;
            PolyLine = polyLine;
            CreatedBy = createdBy;
            EntityType = entityType;
            Surface = surfaceType;
            WayPointsId = wayPointsId;
            WayPointsOrder = wayPointsOrder;
        }

        public decimal Distance { get; set; }
        public decimal Ascent { get; set; }
        public decimal Descent { get; set; }
        public string? Name { get; set; }
        public bool? IsPrivate { get; set; }
        public string PolyLine { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid? EntityType { get; set; }
        public Guid? Surface { get; set; }
        public List<Guid> WayPointsId { get; set; }
        public List<int> WayPointsOrder { get; set; }

    }
}
