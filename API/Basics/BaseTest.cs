using System.IO;
using System.Linq;
using System.Reflection;
using NUnit.Framework.Internal;
using TechTalk.SpecFlow;
using TestContext = NUnit.Framework.TestContext;

namespace Tests.Basics
{
    [Binding]
    public static class BaseTest
    {
        public static TestContext TestContext;
        public static int TestCaseId;                  

        [BeforeTestRun]
        public static void Initializer()
        {
            TestContext = TestContext.CurrentContext;           
        }        

        [BeforeScenario]
        public static void TestInitialize(ScenarioContext scenarioContext)
        {
            TestContext = TestContext.CurrentContext;
            TestCaseId = int.Parse(scenarioContext.ScenarioInfo.Tags.Single(tag => int.TryParse(tag, out TestCaseId)));
        }

        [AfterScenario]
        public static void TestCleanup()
        {
            TestContext = TestContext.CurrentContext;
            var logPath = Path.Combine(TestContext.TestDirectory, $"{TestCaseId}_{TestContext.Test.Name}.log");
            var currentResult = (TestCaseResult)TestContext.Result.GetType().GetRuntimeFields().SingleOrDefault()?.GetValue(TestContext.Result);
            File.WriteAllText(logPath, currentResult?.Output);
            TestContext.AddTestAttachment(logPath);            
        }
    }
}