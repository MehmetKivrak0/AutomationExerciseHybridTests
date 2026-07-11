using Newtonsoft.Json;

namespace AutomationExerciseHybridTests.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
    }

    public class ProductsListResponse
    {
        [JsonProperty("responseCode")]
        public int ResponseCode { get; set; }

        [JsonProperty("products")]
        public List<Product> Products { get; set; } = new();
    }
}