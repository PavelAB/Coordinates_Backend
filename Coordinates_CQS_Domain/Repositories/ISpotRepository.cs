using Coordiantes_Tools.Commands;
using Coordiantes_Tools.Queries;
using Coordinates_CQS_Domain.Commands.Spot;
using Coordinates_CQS_Domain.Entities.Spot;
using Coordinates_CQS_Domain.Queries.Spot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coordinates_CQS_Domain.Repositories
{
    public interface ISpotRepository: 
        ICommandHandler<CreateSpotCommand>,
        IAsyncQueryHandler<GetSpotQuery, List<Spot_Get>>,
        IAsyncQueryHandler<GetSpotLight, List<Spot_Light>>
    {

    }
}
