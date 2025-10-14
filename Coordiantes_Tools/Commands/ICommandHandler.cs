using Coordiantes_Tools.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coordiantes_Tools.Commands
{
    internal interface ICommandHandler<TCommand>
        where TCommand: ICommandDefinition
    {
        ICqsResult Execute(TCommand command);
    }
}
