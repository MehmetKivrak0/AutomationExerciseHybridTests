using Newtonsoft.Json;
using AutomationExerciseHybridTests.Models;

namespace AutomationExerciseHybridTests.Api
{
    public class ProductsApiService
    {
        private readonly ApiClient _apiClient;

        public ProductsApiService()
        {
            _apiClient = new ApiClient();
        }

        public async Task<ProductsListResponse> GetProductsListAsync()
        {
            var response = await _apiClient.GetAsync("/productsList");
            return JsonConvert.DeserializeObject<ProductsListResponse>(response.Content!)!;
        }
        public async Task<RestSharp.RestResponse> PostToProductsListAsync()
        {
            return await _apiClient.PostAsync("/productsList", new Dictionary<string, string>());
        }
    }
}