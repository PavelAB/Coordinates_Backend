using Coordiantes_Tools.Commands;
using Coordiantes_Tools.Queries;
using Coordinates_CQS_Domain.Commands.Users;
using Coordinates_CQS_Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coordinates_CQS_Domain.Repositories
{
    public interface IAuthRepository:
        ICommandHandler<CreateUserCommand>,
        IQueryHandler<CheckPasswordCommand, User>
    {
        
    }
}
