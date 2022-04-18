using Microsoft.Extensions.Configuration;

namespace Internship.Connect.QA.API.AutomationTests.Utils
{
    public class Configurator
    {
        public static IConfiguration GetConfig()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true);
            var config = builder.Build();

            return config;
        }
    }
}