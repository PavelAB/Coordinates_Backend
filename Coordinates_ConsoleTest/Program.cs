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

            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
                .Build();

            ServiceCollection serviceCollection = new();

            serviceCollection.AddSingleton<IConfiguration>(configuration);

            //serviceCollection.AddScoped<IAuthRepository, AuthService>();

            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            // IAuthRepository authRepository = serviceProvider.GetService<IAuthRepository>();


        }
    }
}
