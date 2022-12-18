using Microsoft.Extensions.Configuration;
using Utilities.Extensions;
using Utilities.Helpers;

namespace Utilities.Requests
{
    public static class ExampleEndpoint
    {
        public static string URL => ConfigHelper.Config.GetSection("Example").GetSection("URL")[TestRunHelper.Environment.GetValue()];

        private static IConfigurationSection Endpoint => ConfigHelper.Config.GetSection("Example").GetSection("Endpoint");
        
        public static string Example => $"{URL}{Endpoint["example"]}";
    }
}