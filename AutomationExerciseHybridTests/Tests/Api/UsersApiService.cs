using Newtonsoft.Json;
using AutomationExerciseHybridTests.Models;

namespace AutomationExerciseHybridTests.Api
{
    public class UsersApiService
    {
        private readonly ApiClient _apiClient;

        public UsersApiService()
        {
            _apiClient = new ApiClient();
        }

        public async Task<LoginResponse> VerifyLoginAsync(string email, string password)
        {
            var formData = new Dictionary<string, string>
            {
                { "email", email },
                { "password", password }
            };

            var response = await _apiClient.PostAsync("/verifyLogin", formData);
            return JsonConvert.DeserializeObject<LoginResponse>(response.Content!)!;
        }
    }
}