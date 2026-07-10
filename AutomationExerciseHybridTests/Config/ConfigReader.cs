using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace AutomationExerciseHybridTests.Config
{
    public static class ConfigReader
    {
        private static readonly IConfigurationRoot _config;

        static ConfigReader()
        {
            _config = new ConfigurationBuilder()

            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false)
            .Build();
        }

        public static string BaseUrl => _config["BaseUrl"]!;
        public static string ApiBaseUrl => _config["ApiBaseUrl"]!;
    }
}
