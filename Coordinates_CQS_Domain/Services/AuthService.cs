using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coordinates_CQS_Domain.Services
{
    public class AuthService: BaseService
    {

        private readonly DbConnection _dbConnection;

        public AuthService(IConfiguration configuration) : base(configuration, "localDb")
        {

        }


    }
}
