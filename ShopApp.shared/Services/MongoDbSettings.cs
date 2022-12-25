namespace ShopApp.shared.Services
{
    public class MongoDbSettings : IMongoDbSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CollectionClothes { get; set; }
        public string CollectionUsers { get; set; }
        public string CollectionCategories { get; set; }
        public string CollectionItems { get; set; }
        public string CollectionCarts { get; set; }

    }
}
