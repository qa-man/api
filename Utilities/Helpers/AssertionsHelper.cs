using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System.Net;

namespace Utilities.Helpers
{
    public static class AssertionsHelper
    {
        public static void AssertResponseCode200(RestResponse response) => Assert.IsTrue(response.StatusCode == HttpStatusCode.OK, $"Expected Status Code: '200' | Actual Status Code: '{response.StatusCode}'");
    }
}