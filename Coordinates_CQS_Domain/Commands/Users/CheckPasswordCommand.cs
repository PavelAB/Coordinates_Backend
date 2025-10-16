using Coordiantes_Tools.Commands;
using Coordiantes_Tools.Queries;
using Coordinates_CQS_Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coordinates_CQS_Domain.Commands.Users
{
    public class CheckPasswordCommand : IQueryDefinition<User>
    {

        public string Login { get; }
        public string Password { get; }
        public CheckPasswordCommand(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}
