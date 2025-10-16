using Coordiantes_Tools.Commands;
using Coordinates_CQS_Domain.Commands.Spot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coordinates_CQS_Domain.Repositories
{
    public interface ISpotRepository: 
        ICommandHandler<CreateSpotCommand>
    {

    }
}
