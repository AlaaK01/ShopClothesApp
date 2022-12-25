using ShopApp.shared.Dtos;
using ShopApp.shared.Models;

namespace ShopApp.shared.Services
{
    public interface IItemServices
    {
        Task<Item> AddItem(ItemToAddDto itemToAddDto);
        Task<Item> DeleteItem(string id);
        Task<Item> GetItem(string id);
        Task<List<Item>> GetItems(string userId);
        Task<Item> UpdateQuantity(string id, UpdateItemQuantityDto updateItemQuantityDto);
    }
}