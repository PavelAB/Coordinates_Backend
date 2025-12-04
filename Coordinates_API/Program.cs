
using Coordiantes_Tools.Tools;
using Coordinates_API.Tools;
using Coordinates_CQS_Domain.Repositories;
using Coordinates_CQS_Domain.Services;
using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Coordinates_API
{
    public partial class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

            // Add services to the container.

            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            Env.TraversePath().Load();
            EnvConfig envConfig = new();


            builder.Services.AddSingleton<EnvConfig>();

            JwtOptions jwtOptions = new(
                envConfig.Get("TOKEN_ISSUER")!,
                envConfig.Get("TOKEN_AUDIENCE")!,
                envConfig.Get("TOKEN_SECURITY_KEY")!
                );
            builder.Services.AddSingleton(sp => jwtOptions);
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
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

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,

                                  policy =>
                                  {
                                      //policy.AllowAnyOrigin().AllowAnyHeader();
                                      //policy.WithOrigins("http://localhost:8080").AllowAnyHeader();
                                      policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
                                  });
            });


            builder.Services.AddScoped<ITokenRepository, TokenService>();
            builder.Services.AddScoped<IAuthRepository, AuthService>();
            builder.Services.AddScoped<ISpotRepository, SpotService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();


            app.MapControllers();

            app.Run();


        }
        
    }

}
