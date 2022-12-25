namespace ShopApp.shared.Services
{
    public interface IMongoDbSettings
    {
        string CollectionCarts { get; set; }
        string CollectionCategories { get; set; }
        string CollectionClothes { get; set; }
        string CollectionItems { get; set; }
        string CollectionUsers { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}