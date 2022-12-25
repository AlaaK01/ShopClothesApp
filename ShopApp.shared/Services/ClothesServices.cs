using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ShopApp.shared.Models;



namespace ShopApp.shared.Services
{
    public class ClothesServices : IClothesServices
    {
        private readonly IMongoCollection<Cloth> _clothes;
        private readonly IMongoCollection<Category> _categories;
        public ClothesServices(IOptions<MongoDbSettings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _clothes = client.GetDatabase(options.Value.DatabaseName).GetCollection<Cloth>(options.Value.CollectionClothes);
            _categories = client.GetDatabase(options.Value.DatabaseName).GetCollection<Category>(options.Value.CollectionCategories);
        }

        public async Task<List<Cloth>> GetClothes() => await _clothes.Find(x => true).ToListAsync();
        public async Task<List<Category>> GetCategories() => await _categories.Find(x => true).ToListAsync();
        public async Task<Category> GetCategoryById(string id) => await _categories.Find(c => c.Id == id).SingleOrDefaultAsync();
        public async Task<Cloth> GetClothById(string id) => await _clothes.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task<List<Cloth>> GetClothByCategory(string id)
        {
            var category = await GetCategoryById(id);
            return await _clothes.Find(x => x.Category == category.CategoryName).ToListAsync();
        }
    }
}