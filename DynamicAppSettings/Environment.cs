using Microsoft.Extensions.Configuration;

namespace DynamicAppSettings
{
    public class Environment : IEnvironment
    {
        private readonly IConfiguration _configuration;

        public Environment(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetEnvironmentDetails()
        {
            var result = _configuration.GetValue<string>("EnvironmentName");
            return result;
        }
    }
}
