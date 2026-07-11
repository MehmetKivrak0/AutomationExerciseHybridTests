using Newtonsoft.Json;

namespace AutomationExerciseHybridTests.Models
{
    public class LoginResponse
    {
        [JsonProperty("responseCode")]
        public int ResponseCode { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; } = string.Empty;
    }
}