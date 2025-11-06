using Coordiantes_Tools.Commands;
using Coordinates_CQS_Domain.Commands.Track;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coordinates_CQS_Domain.Repositories
{
    public interface ITrackRepository: ICommandHandler<CreateTrackCommand>
    {
    }
}
