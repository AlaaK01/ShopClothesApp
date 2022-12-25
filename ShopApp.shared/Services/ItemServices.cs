using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ShopApp.shared.Dtos;
using ShopApp.shared.Models;


namespace ShopApp.shared.Services
{
    public class ItemServices : IItemServices
    {

        private readonly IMongoCollection<Cloth> _clothes;
        private readonly IMongoCollection<Cart> _carts;
        private readonly IMongoCollection<Item> _items;
        public ItemServices(IOptions<MongoDbSettings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);

            _clothes = client.GetDatabase(options.Value.DatabaseName).GetCollection<Cloth>(options.Value.CollectionClothes);
            _carts = client.GetDatabase(options.Value.DatabaseName).GetCollection<Cart>(options.Value.CollectionCarts);
            _items = client.GetDatabase(options.Value.DatabaseName).GetCollection<Item>(options.Value.CollectionItems);
        }

        public async Task<Item> GetItem(string id)
        {
            var item = await _items.Find(x => x.Id == id).SingleOrDefaultAsync();
            var cart = await _carts.Find(x => x.Id == item.CartId).SingleOrDefaultAsync();
            return await _items.Find(x => x.CartId == cart.Id).SingleOrDefaultAsync();
        }

        public async Task<List<Item>> GetItems(string userId)
        {
            var cart = await _carts.Find(x => x.UserId == userId).SingleOrDefaultAsync();
            return await _items.Find(x => x.CartId == cart.Id).ToListAsync();
        }


        public async Task<Item> AddItem(ItemToAddDto itemToAddDto)
        {
            if (await IsItemExists(itemToAddDto.CartId, itemToAddDto.ClothId) == false)
            {
                var cloth = await _clothes.Find(x => x.Id == itemToAddDto.ClothId).FirstOrDefaultAsync();
                var newItem = new Item
                {
                    CartId = itemToAddDto.CartId,
                    ClothId = cloth.Id,
                    Quantity = itemToAddDto.Quantity
                };
                if (newItem != null)
                {
                    var result = _items.InsertOneAsync(newItem);

                    return newItem;
                }
            }
            return null;
        }


        public async Task<Item> DeleteItem(string id)
        {
            var item = await _items.Find(x => x.Id == id).SingleOrDefaultAsync();

            if (item != null)
            {
                await _items.DeleteOneAsync(x => x.Id == id);
            }
            return item;
        }



        public async Task<Item> UpdateQuantity(string id, UpdateItemQuantityDto updateItemQuantityDto)
        {
            var item = await _items.Find(x => x.Id == id).SingleOrDefaultAsync();
            if (item != null)
            {
                item.Quantity = updateItemQuantityDto.Quantity;
                await _items.ReplaceOneAsync(x => x.Id == id, item);
                return item;
            }
            return null;
        }

        private async Task<bool> IsItemExists(string cartId, string clothId)
        {
            var itemExists = await _items.Find(x => x.Id == cartId && x.ClothId == clothId).SingleOrDefaultAsync();
            return (itemExists is null) ? false : true;

        }
    }
}
