using MongoDB.Bson.Serialization.Attributes;




namespace ShopApp.shared.Models
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("CategoryName")]
        public string CategoryName { get; set; } = string.Empty;
    }
}
