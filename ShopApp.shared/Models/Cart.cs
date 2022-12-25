

using MongoDB.Bson.Serialization.Attributes;

namespace ShopApp.shared.Models
{
    public class Cart
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("userId")]
        public string UserId { get; set; }
    }
}
