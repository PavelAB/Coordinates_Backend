using Coordiantes_Tools.Results;
using Coordiantes_Tools.Tools;
using Coordinates_API.Tools;
using Coordinates_CQS_Domain.Commands.Spot;
using Coordinates_CQS_Domain.Commands.Users;
using Coordinates_CQS_Domain.Entities.Track;
using Coordinates_CQS_Domain.Entities.User;
using Coordinates_CQS_Domain.Queries.ORS;
using Coordinates_CQS_Domain.Queries.User;
using Coordinates_CQS_Domain.Repositories;
using Coordinates_CQS_Domain.Services;
using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Coordinates_ConsoleTest
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, Coordinates Console Test Project!");

            ServiceCollection serviceCollection = new();

            Env.TraversePath().Load();
            EnvConfig envConfig = new();


            
            JwtOptions jwtOptions = new(
                envConfig.Get("TOKEN_ISSUER")!,
                envConfig.Get("TOKEN_AUDIENCE")!,
                envConfig.Get("TOKEN_SECURITY_KEY")!
                );

            serviceCollection.AddSingleton(sp => jwtOptions);
            serviceCollection.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = false,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtOptions.Issuer,
                        ValidAudience = jwtOptions.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecurityKey))
                    };
                });


            serviceCollection.AddSingleton<EnvConfig>();
            serviceCollection.AddScoped<IAuthRepository, AuthService>();
            serviceCollection.AddScoped<ITokenRepository, TokenService>();
            serviceCollection.AddScoped<ISpotRepository, SpotService>();
            serviceCollection.AddScoped<IORSRepository, ORSService>();

            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            IAuthRepository authRepository = serviceProvider.GetService<IAuthRepository>();
            ITokenRepository tokenRepository = serviceProvider.GetService<ITokenRepository>();
            ISpotRepository spotRepository = serviceProvider.GetService<ISpotRepository>();
            IORSRepository orsRepository = serviceProvider.GetRequiredService<IORSRepository>();

            #region Create User

            //CreateUserCommand newUser = new("WorsePerson", "Bad2", "bad@world2.net", "0000");
            //ICqsResult resultUser = authRepository.Execute(newUser);
            //Console.WriteLine($"User created : {resultUser.IsSuccess}");

            #endregion

            #region CheckPassword


            //CheckPasswordQuery checkPasswordCommandBad = new("Bad2", "0001");
            //ICqsResult<User> resultBad = authRepository.Execute(checkPasswordCommandBad);
            //Console.WriteLine(resultBad.ErrorMessage);

            //CheckPasswordQuery checkPasswordCommand = new("Bad2", "0000");
            //ICqsResult<User> result = authRepository.Execute(checkPasswordCommand);
            //User newUserAuth = result.Content;
            //newUserAuth.Token = tokenRepository.GenerateToken(newUserAuth);
            //Console.WriteLine("IdUser: " + result.Content.IdUser);
            //Console.WriteLine("Token: " + result.Content.Token);
            #endregion

            #region Create Spot

            //CreateSpotCommand createSpotCommand = new(
            //    -45m, 
            //    -154.59843m, 
            //    1546.52m, 
            //    "MyFavoriteSpot",
            //    new Guid(newUserAuth.IdUser!.ToString()),
            //    new Guid("37FF90EB-0E05-4FF7-9D11-FBBCCEFE59AD"),
            //    new Guid("9953864A-1857-4545-804B-FFA7AB76E0B7")
            //);
            //ICqsResult resultSpot = spotRepository.Execute(createSpotCommand);
            //Console.WriteLine($"Spot created : {resultSpot.IsSuccess}");
            //if (resultSpot.IsFailure)
            //{
            //    Console.WriteLine($"Spot created : {resultSpot.IsFailure}");
            //    Console.WriteLine(resultSpot.ErrorMessage);
            //}

            #endregion

            #region ORS Test
            //end lat=50.606282&lon=4.225678
            //start lat=50.493968&lon=4.287420

            GetTrackORSQuery newTrack = new("4.287420,50.493968", "4.225678,50.606282", envConfig.Get("SECURITY_ORS_KEY")!);
            ICqsResult<TrackCreate> test = await orsRepository.ExecuteAsync(newTrack);
            Console.WriteLine($"Distance: {test.Content.Distance} ");
            Console.WriteLine($"PolyLine: {test.Content.PolyLine} ");

            #endregion
        }
    }
}
