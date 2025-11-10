using Azure.Core;
using Coordiantes_Tools.Tools;
using Coordinates_CQS_Domain.Entities.User;
using Coordinates_CQS_Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Coordinates_CQS_Domain.Services
{
    public class TokenService : ITokenRepository
    {
        private readonly JwtOptions _jwtOptions;
        private const string _PREFIX = "Bearer ";

        public TokenService(JwtOptions jwtOptions)
        {
            _jwtOptions = jwtOptions;
        }

        public string GenerateToken(User user)
        {
            SymmetricSecurityKey _securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecurityKey));

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Sid, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.PrimarySid, user.IdUser.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Login)
            };

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                signingCredentials: new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha256)
                );

            string token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            return string.Concat(_PREFIX, token);
        }

        public Guid ReadFromToken(HttpRequest httpRequest)
        {
            StringValues authorizations = httpRequest.Headers.SingleOrDefault(h => h.Key == "Authorization").Value;
            string? token = authorizations.SingleOrDefault(a => a.StartsWith(_PREFIX));

            if (token is null)
                throw new InvalidOperationException("token is null");

            token = token.Replace(_PREFIX, "");

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwtSecurityToken = (JwtSecurityToken)handler.ReadToken(token);

            JwtPayload payload = jwtSecurityToken.Payload;


            string? claimGuid = payload[ClaimTypes.PrimarySid].ToString();

            if(claimGuid is null)
                throw new InvalidOperationException("Claim error");

            Guid userId = new Guid(claimGuid);

            return userId;

        }
    }
}
