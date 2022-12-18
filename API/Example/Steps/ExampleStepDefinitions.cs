using System;
using TechTalk.SpecFlow;
using Tests.Basics;
using Utilities.Requests;

namespace Tests.Example.Steps
{
    [Binding]
    [Scope(Tag = "Example")]
    public class ExampleStepDefinitions : CommonStepDefinitions
    {
        [Given(@"User sends Get request with ""([^""]*)"" suffix")]
        public void GivenISendGetRequestWithKey(string suffix)
        {
            response = new ExampleRequests().GetExampleResponse($"{ExampleEndpoint.Example}{suffix}");
            Console.WriteLine($"'{response.Content}' in response for '{ExampleEndpoint.Example}{suffix}'");
        }       
    }
}
