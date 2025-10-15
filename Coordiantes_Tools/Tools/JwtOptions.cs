using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coordiantes_Tools.Tools
{
    public class JwtOptions
    {

        public string Issuer { get; }
        public string Audience { get; }
        public string SecurityKey { get; }

        public JwtOptions(string issuer, string audience, string securityKey)
        {
            Issuer = issuer;
            Audience = audience;
            SecurityKey = securityKey;
        }

    }
}
