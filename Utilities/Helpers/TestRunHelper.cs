using NUnit.Framework;
using Utilities.Enums;

namespace Utilities.Helpers
{
    public static class TestRunHelper
    {
        public static Environment Environment => (Environment)System.Enum.Parse(typeof(Environment), $"{TestContext.Parameters["environment"]?.ToLower()}");

        public static string PAT => $"{TestContext.Parameters["pat"]}";
    }
}