using Coordinates_API.Tools;
using Coordinates_CQS_Domain.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coordinates_CQS_Domain.Services
{
    public class AuthService: BaseService, IAuthRepository
    {

        private readonly DbConnection _dbConnection;

        public AuthService(EnvConfig env) : base(env)
        {

        }

        
    }
}
