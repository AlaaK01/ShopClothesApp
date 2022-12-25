
using ShopApp.shared.Dtos;
using System.Net.Http.Json;
using System.Text;


using Newtonsoft.Json;

namespace ShopApp.client.ClientServices
{
    public class ClientItemsService : IClientItemsService
    {
        private readonly HttpClient _httpClient;
        public ClientItemsService(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<CartItemDto> AddItem(ItemToAddDto itemToAddDto)
        {

            var response = await _httpClient.PostAsJsonAsync<ItemToAddDto>("api/Items", itemToAddDto);

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return default(CartItemDto);
                }

                return await response.Content.ReadFromJsonAsync<CartItemDto>();

            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                throw new Exception($"Http status:{response.StatusCode} Message -{message}");
            }


        }

        public async Task<CartItemDto> DeleteItem(string id)
        {

            var response = await _httpClient.DeleteAsync($"api/Items/{id}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<CartItemDto>();
            }
            return default(CartItemDto);

        }

        public async Task<List<CartItemDto>> GetItems(string userId)
        {

            var response = await _httpClient.GetAsync($"api/Items/{userId}/GetItems");

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return Enumerable.Empty<CartItemDto>().ToList();
                }
                return await response.Content.ReadFromJsonAsync<List<CartItemDto>>();
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                throw new Exception($"Http status code: {response.StatusCode} Message: {message}");
            }

        }

        public async Task<CartItemDto> UpdateQuantity(UpdateItemQuantityDto updateItemQuantityDto)
        {
            var jsonRequest = JsonConvert.SerializeObject(updateItemQuantityDto);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json-patch+json");
            var response = await _httpClient.PatchAsync($"api/Items/{updateItemQuantityDto.CartItemId}", content);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<CartItemDto>();
            }
            return null;
        }
    }
}
