using ShopApp.shared.Dtos;
using System.Net.Http.Json;
using System.Text;

namespace ShopApp.client.ClientServices
{
    public class ClientClothesServices : IClientClothesServices
    {
        private readonly HttpClient _httpClient;
        public ClientClothesServices(HttpClient httpClient) => _httpClient = httpClient;


        public async Task<ClothDto> GetItem(string id)
        {

            var response = await _httpClient.GetAsync($"api/Clothes/{id}");

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return default(ClothDto);
                }

                return await response.Content.ReadFromJsonAsync<ClothDto>();
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                throw new Exception($"Http status code: {response.StatusCode} message: {message}");
            }

        }

        public async Task<IEnumerable<ClothDto>> GetItems()
        {
            var response = await _httpClient.GetAsync("api/Clothes");

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return Enumerable.Empty<ClothDto>();
                }

                return await response.Content.ReadFromJsonAsync<IEnumerable<ClothDto>>();
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                throw new Exception($"Http status code: {response.StatusCode} message: {message}");
            }


        }

        public async Task<IEnumerable<ClothDto>> GetClothesByCategory(string categoryId)
        {

            var response = await _httpClient.GetAsync($"api/Clothes/{categoryId}/GetClothesByCategory");

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return Enumerable.Empty<ClothDto>();
                }
                return await response.Content.ReadFromJsonAsync<IEnumerable<ClothDto>>();
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                throw new Exception($"Http Status Code - {response.StatusCode} Message - {message}");
            }

        }

        public async Task<IEnumerable<CategoryDto>> GetCategories()
        {

            var response = await _httpClient.GetAsync("api/Clothes/GetCategories");

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return Enumerable.Empty<CategoryDto>();
                }
                return await response.Content.ReadFromJsonAsync<IEnumerable<CategoryDto>>();
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                throw new Exception($"Http Status Code - {response.StatusCode} Message - {message}");
            }

        }


    }
}