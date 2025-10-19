using Coordiantes_Tools.Queries;
using Coordinates_CQS_Domain.Entities.Track;
using Coordinates_CQS_Domain.Queries.ORS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coordinates_CQS_Domain.Repositories
{
    public interface IORSRepository : IAsyncQueryHandler<GetTrackORSQuery, TrackCreate>
    {

    }
}
