using Coordiantes_Tools.Commands;
using Coordiantes_Tools.Queries;
using Entity = Coordinates_CQS_Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coordinates_CQS_Domain.Queries.User
{
    public class CheckPasswordQuery : IQueryDefinition<Entity.User>
    {

        public string Login { get; }
        public string Password { get; }
        public CheckPasswordQuery(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}
