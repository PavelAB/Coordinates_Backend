using DotNetEnv;
using System.Collections;

namespace Coordinates_API.Tools
{
    public class EnvConfig
    {

        public EnvConfig() 
        {
            Env.TraversePath().Load();
        }

        public string? Get(string key)
        {
            return Environment.GetEnvironmentVariable(key);
        }

        
    }
}
