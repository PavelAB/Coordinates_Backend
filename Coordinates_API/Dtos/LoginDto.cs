namespace Coordinates_API.Dtos
{
    public class LoginDto
    {

        public string Login { get; }

        public string Password { get; }

        public LoginDto(string login, string password)
        {
            Login = login;
            Password = password;
        }
        
    }
}
