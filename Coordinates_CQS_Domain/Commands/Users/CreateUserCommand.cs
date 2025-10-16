using Coordiantes_Tools.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coordinates_CQS_Domain.Commands.Users
{
    public class CreateUserCommand : ICommandDefinition
    {

        public string NickName { get; }
        public string Login { get; }
        public string Email { get; }
        public string Password { get; }
        public CreateUserCommand(string nickName, string login, string email, string password)
        {
            NickName = nickName;
            Login = login;
            Email = email;
            Password = password;
        }
    }
}
