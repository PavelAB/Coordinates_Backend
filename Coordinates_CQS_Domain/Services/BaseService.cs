using Coordinates_API.Tools;
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
        public BaseService(EnvConfig env)
        {
            _connectonString = env.Get("CONNECTION_STRING");

        }
    }
}
