using MongoDB.Bson.Serialization.Attributes;




namespace ShopApp.shared.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        
        [BsonElement("userName")]
        public string UserName { get; set; } = string.Empty;
        [BsonElement("password")]
        public string Password { get; set; } = string.Empty;
        [BsonElement("email")]
        public string Email { get; set; } = string.Empty;
    }
}
