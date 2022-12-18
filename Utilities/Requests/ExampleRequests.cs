using RestSharp;

namespace Utilities.Requests
{
    public class ExampleRequests
    {
        public RestResponse GetExampleResponse(string endpoint)
        {
            RestClient client = new(endpoint);
            var request = new RestRequest($"{endpoint}", Method.Get);
            request.AddParameter("application/json", ParameterType.RequestBody);
            return client.Execute(request);
        }
    }
}