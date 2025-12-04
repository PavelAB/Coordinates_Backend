using Coordiantes_Tools.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coordinates_CQS_Domain.Commands.Spot
{
    public class DeleteSpotCommand: ICommandDefinition
    {
        public DeleteSpotCommand(Guid idSpot, Guid deletedBy)
        {
            IdSpot = idSpot;
            DeletedBy = deletedBy;
        }

        public Guid IdSpot { get; set; }
        public Guid DeletedBy { get; set; }
    }
}
