using Coordinates_CQS_Domain.Entities.User;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coordinates_CQS_Domain.Repositories
{
    public interface ITokenRepository
    {
        string GenerateToken(User user);
        Guid ReadFromToken(HttpRequest httpRequest);
    }
}
