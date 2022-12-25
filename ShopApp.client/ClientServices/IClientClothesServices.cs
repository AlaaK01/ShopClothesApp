using ShopApp.shared.Dtos;

namespace ShopApp.client.ClientServices
{
    public interface IClientClothesServices
    {
        Task<IEnumerable<CategoryDto>> GetCategories();
        Task<IEnumerable<ClothDto>> GetClothesByCategory(string categoryId);
        Task<ClothDto> GetItem(string id);
        Task<IEnumerable<ClothDto>> GetItems();
    }
}