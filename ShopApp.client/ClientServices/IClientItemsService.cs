using ShopApp.shared.Dtos;

namespace ShopApp.client.ClientServices
{
    public interface IClientItemsService
    {
        Task<CartItemDto> AddItem(ItemToAddDto itemToAddDto);
        Task<CartItemDto> DeleteItem(string id);
        Task<List<CartItemDto>> GetItems(string userId);
        Task<CartItemDto> UpdateQuantity(UpdateItemQuantityDto updateItemQuantityDto);
    }
}