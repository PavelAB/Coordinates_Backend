using Coordiantes_Tools.Results;
using Coordiantes_Tools.Tools;
using Coordinates_API.Tools;
using Coordinates_CQS_Domain.Commands.Spot;
using Coordinates_CQS_Domain.Commands.Track;
using Coordinates_CQS_Domain.Commands.Users;
using Coordinates_CQS_Domain.Entities.Spot;
using Coordinates_CQS_Domain.Entities.Track;
using Coordinates_CQS_Domain.Entities.User;
using Coordinates_CQS_Domain.Queries.ORS;
using Coordinates_CQS_Domain.Queries.Spot;
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
            serviceCollection.AddScoped<ITrackRepository, TrackService>();

            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            IAuthRepository authRepository = serviceProvider.GetService<IAuthRepository>();
            ITokenRepository tokenRepository = serviceProvider.GetService<ITokenRepository>();
            ISpotRepository spotRepository = serviceProvider.GetService<ISpotRepository>();
            IORSRepository orsRepository = serviceProvider.GetRequiredService<IORSRepository>();
            ITrackRepository trackRepository = serviceProvider.GetRequiredService<ITrackRepository>();

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

            try
            {
                GetSpotQuery getSpotQueryStart = new(longitude: 4.225678m, latitude: 50.606282m);
                ICqsResult<Spot_Get> resultStart = await spotRepository.ExecuteAsync(getSpotQueryStart);
                Spot_Get newSpotStart = null;
                if (resultStart.IsSuccess)
                {
                    newSpotStart = resultStart.Content;
                    Console.WriteLine($"Result: IdSpot = {newSpotStart.IdSpot}");
                    Console.WriteLine($"ResultEnd: Name = {newSpotStart.Name}");

                }
                else if (resultStart.IsFailure)
                {
                    Console.WriteLine($"Result: IdSpot = {resultStart.ErrorMessage}");

                    CreateSpotCommand createSpotCommand = new(
                        50.606282m,
                        4.225678m,
                        140m,
                        "MyFavoriteSpot-Ronq",
                        new Guid("2A065D32-88EB-4CEA-9713-866ACC632733")
                    );

                    ICqsResult resultSpot = spotRepository.Execute(createSpotCommand);
                    Console.WriteLine($"Spot created : {resultSpot.IsSuccess}");
                    if (resultSpot.IsFailure)
                    {
                        Console.WriteLine($"Spot created : {resultSpot.IsFailure}");
                        Console.WriteLine(resultSpot.ErrorMessage);
                    }


                    ICqsResult<Spot_Get> resultAfterInsert = await spotRepository.ExecuteAsync(getSpotQueryStart);
                    newSpotStart = resultAfterInsert.Content;
                    Console.WriteLine($"Result: IdSpot = {newSpotStart.IdSpot}");
                    Console.WriteLine($"ResultEnd: Name = {newSpotStart.Name}");
                }

                //lat = 50.476236 & lon = 4.473592

                GetSpotQuery getSpotQueryEnd = new(longitude: 4.473592m, latitude: 50.476236m);
                ICqsResult<Spot_Get> resultEnd = await spotRepository.ExecuteAsync(getSpotQueryEnd);
                Spot_Get newSpotEnd = null;
                if (resultEnd.IsSuccess)
                {
                    newSpotEnd = resultEnd.Content;
                    Console.WriteLine($"ResultEnd: IdSpot = {newSpotEnd.IdSpot}");
                    Console.WriteLine($"ResultEnd: Name = {newSpotEnd.Name}");

                }
                else if (resultEnd.IsFailure)
                {
                    Console.WriteLine($"ResultEnd: IdSpot = {resultEnd.ErrorMessage}");

                    CreateSpotCommand createSpotCommandEnd = new(
                        50.476236m,
                        4.473592m,
                        136m,
                        "MyFavoriteSpot-Gosselies",
                        new Guid("2A065D32-88EB-4CEA-9713-866ACC632733")
                    );

                    ICqsResult resultSpotEnd2 = spotRepository.Execute(createSpotCommandEnd);
                    Console.WriteLine($"Spot created : {resultSpotEnd2.IsSuccess}");
                    if (resultSpotEnd2.IsFailure)
                    {
                        Console.WriteLine($"Spot created : {resultSpotEnd2.IsFailure}");
                        Console.WriteLine(resultSpotEnd2.ErrorMessage);
                    }


                    ICqsResult<Spot_Get> resultAfterInsertEnd = await spotRepository.ExecuteAsync(getSpotQueryEnd);
                    newSpotEnd = resultAfterInsertEnd.Content;
                    Console.WriteLine($"ResultEnd: IdSpot = {newSpotEnd.IdSpot}");
                    Console.WriteLine($"ResultEnd: Name = {newSpotEnd.Name}");
                }

                Console.WriteLine("Before ORS");


                GetTrackORSQuery newTrack = new(
                    new (decimal Longitude, decimal Latitude)[]
                    {
                        (newSpotStart.Longitude, newSpotStart.Latitude),
                        (newSpotEnd.Longitude, newSpotEnd.Latitude)
                    },
                    envConfig.Get("SECURITY_ORS_KEY")!
                ) ;

                ICqsResult<TrackCreate> test = await orsRepository.ExecuteAsync(newTrack);
                Console.WriteLine("After ORS");
                Console.WriteLine($"Distance: {test.Content.Distance} ");
                Console.WriteLine($"PolyLine: {test.Content.PolyLine.Length} ");
                Console.WriteLine($"Ascent: {test.Content.Ascent} ");
                Console.WriteLine($"Descent: {test.Content.Descent} ");


                CreateTrackCommand createTrackCommand = new(
                    test.Content.Distance,
                    test.Content.Ascent,
                    test.Content.Descent,
                    test.Content.PolyLine,
                    new Guid("2A065D32-88EB-4CEA-9713-866ACC632733"),
                    [newSpotStart.IdSpot, newSpotEnd.IdSpot],
                    test.Content.WayPoints
                    );
                ICqsResult resultTrack = trackRepository.Execute(createTrackCommand);
                Console.WriteLine($"Track created : {resultTrack.IsSuccess}");
                if (resultTrack.IsFailure)
                {
                    Console.WriteLine($"Track created : {resultTrack.IsFailure}");
                    Console.WriteLine(resultTrack.ErrorMessage);
                }



            }
            catch (Exception e)
            {

                Console.WriteLine($"Error: {e.Message}");
            }
            
            
            //try
            //{



            //    GetTrackORSQuery newTrack = new(
            //        new (decimal Longitude, decimal Latitude)[]
            //        {
            //            (4.287420m, 50.493968m),
            //            (4.225678m, 50.606282m)
            //        },
            //        envConfig.Get("SECURITY_ORS_KEY")!
            //    );


            //    ICqsResult<TrackCreate> test = await orsRepository.ExecuteAsync(newTrack);
            //    Console.WriteLine($"Distance: {test.Content.Distance} ");
            //    Console.WriteLine($"PolyLine: {test.Content.PolyLine.Length} ");
            //    Console.WriteLine($"Ascent: {test.Content.Ascent} ");
            //    Console.WriteLine($"Descent: {test.Content.Descent} ");
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            #endregion
        }
    }
}
