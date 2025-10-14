using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coordinates_CQS_Domain.Services
{
    public class BaseService
    {
        protected readonly string _connectonString;
        public BaseService(IConfiguration configuration, string connectionString)
        {
            _connectonString = configuration.GetConnectionString(connectionString);
        }
    }
}
