using ShopApp.shared.Models;

namespace ShopApp.shared.Services
{
    public interface IClothesServices
    {
        Task<List<Category>> GetCategories();
        Task<Category> GetCategoryById(string id);
        Task<List<Cloth>> GetClothByCategory(string id);
        Task<Cloth> GetClothById(string id);
        Task<List<Cloth>> GetClothes();
    }
}