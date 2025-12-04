using Coordiantes_Tools.Commands;
using Coordiantes_Tools.Queries;
using Coordinates_CQS_Domain.Commands.Track;
using Coordinates_CQS_Domain.Entities.Track;
using Coordinates_CQS_Domain.Queries.Track;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coordinates_CQS_Domain.Repositories
{
    public interface ITrackRepository: 
        ICommandHandler<CreateTrackCommand>,
        ICommandHandler<UpdateTrackCommand>,
        IAsyncQueryHandler<GetTrackQuery, List<Track_Get>>
    {
    }
}
