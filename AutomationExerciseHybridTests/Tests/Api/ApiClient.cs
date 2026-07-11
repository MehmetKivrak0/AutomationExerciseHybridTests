using RestSharp;
using AutomationExerciseHybridTests.Config;

namespace AutomationExerciseHybridTests.Api
{
    public class ApiClient
    {
        private readonly RestClient _client;

        public ApiClient()
        {
            _client = new RestClient(ConfigReader.ApiBaseUrl);
        }

        public async Task<RestResponse> GetAsync(string endpoint)
        {
            var request = new RestRequest(endpoint, Method.Get);
            return await _client.ExecuteAsync(request);
        }
        public async Task<RestResponse> PostAsync(string endpoint, Dictionary<string, string> formData)
        {
            var request = new RestRequest(endpoint, Method.Post);

            foreach (var field in formData)
            {
                request.AddParameter(field.Key, field.Value);
            }

            return await _client.ExecuteAsync(request);
        }
    }
}