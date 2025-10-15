using Coordinates_API.Tools;
using Coordinates_CQS_Domain.Repositories;
using Coordinates_CQS_Domain.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Coordinates_ConsoleTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Coordinates Console Test Project!");

            ServiceCollection serviceCollection = new();


            serviceCollection.AddSingleton<EnvConfig>();
            serviceCollection.AddScoped<IAuthRepository, AuthService>();

            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            IAuthRepository authRepository = serviceProvider.GetService<IAuthRepository>();


        }
    }
}
