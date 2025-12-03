using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Coordinates_API;
using Coordinates_Tests.Auth;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.SqlClient;
using Coordinates_CQS_Domain.Commands.Users;
using Coordiantes_Tools.Results;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data;
using Coordinates_API.Tools;
using DotNetEnv;


namespace Coordinates_Tests.Infrastructure
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Development");

            Env.TraversePath().Load();
            EnvConfig envConfig = new EnvConfig();

            string? testConnectionString = envConfig.Get("CONNECTION_STRING_TEST");

            if (string.IsNullOrWhiteSpace(testConnectionString))
                throw new InvalidOperationException("CONNECTION_STRING_TEST n'est pas défini dans le .env");


            Environment.SetEnvironmentVariable(
                "CONNECTION_STRING",
                testConnectionString
                );

            builder.ConfigureTestServices(services =>
            {
                services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = TestAuthHandler.SchemeName;
                    options.DefaultChallengeScheme = TestAuthHandler.SchemeName;
                })
                .AddScheme<AuthenticationSchemeOptions, TestAuthHandler>(
                    TestAuthHandler.SchemeName, options => { });
            });

            InitializeTestDatabase();
        }
        private static void InitializeTestDatabase()
        {
            string? connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException(
                    "La variable d'environnement CONNECTION_STRING n'est pas définie pour les tests.");
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand deleteCommand = connection.CreateCommand())
                {
                    deleteCommand.CommandType = CommandType.Text;

                    // 1) VIDER LES TABLES (ordre : enfants -> parents)
                    deleteCommand.CommandText = @"
                        DELETE FROM [User];
                    ";
                    deleteCommand.ExecuteNonQuery();
                }


                CreateUserCommand newUser = new("WorsePerson", "Bad2.1", "bad.1@world2.net", "0000");

                using (SqlCommand insertCommand = connection.CreateCommand())
                {
                    



                    insertCommand.CommandText = "dbo.SP_User_Create";
                    insertCommand.CommandType = CommandType.StoredProcedure;
                    insertCommand.Parameters.AddWithValue("@nickName", newUser.NickName);
                    insertCommand.Parameters.AddWithValue("@email", newUser.Email);
                    insertCommand.Parameters.AddWithValue("@login", newUser.Login);
                    insertCommand.Parameters.AddWithValue("@userPassword", newUser.Password);


                    insertCommand.ExecuteNonQuery();
                    
                }

            }
        }
    }
}
