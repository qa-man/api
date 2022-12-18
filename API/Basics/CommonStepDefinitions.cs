using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using RestSharp;
using TechTalk.SpecFlow;
using Utilities.Extensions;
using Utilities.Helpers;

namespace Tests.Basics
{
    [Binding]
    public class CommonStepDefinitions
    {
        protected RestResponse response;

        [Then(@"The response code should be equal '200'")]
        public void ThenResponseCodeShouldBeEqualTo()
        {
            AssertionsHelper.AssertResponseCode200(response);
        }

        [Then(@"The response should contain the following values")]
        public void ThenTheResponseShouldContainTheFollowingValues(Table table)
        {
            var dynamicResponse = response.Content;

            var data = table.ToDictionary();
            var obj = JArray.Parse(dynamicResponse!);

            foreach (var jsonKey in obj)
            {
                var key = jsonKey["name"]!.Value<string>();
                var value = jsonKey["value"]!.Value<string>();
                Assert.IsTrue(data.ContainsKey(key), $"Name: {key} incorrect");
                Assert.IsTrue(data.ContainsValue(value), $"Value: {value}  incorrect");
            }
        }
    }
}
