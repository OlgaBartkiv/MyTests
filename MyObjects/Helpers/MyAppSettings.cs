using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MyObjects.Helpers
{
    public enum Section
    {
        Urls
    }

    public static class MyAppSettings
    {
        private static readonly IConfiguration _configuration;

        static MyAppSettings()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(TestContext.CurrentContext.TestDirectory)
                .AddJsonFile(@"appsettings.json", false, false)
                .Build();
        }

        public static string GetConfig(Section section, string configName)
        {
            return _configuration.GetSection($"{section}:{configName}").Value;
        }
    }
}
