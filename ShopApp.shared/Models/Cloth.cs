using MongoDB.Bson.Serialization.Attributes;


namespace ShopApp.shared.Models
{
    [BsonIgnoreExtraElements]
    public class Cloth
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        
        [BsonElement("Name")]
        public string ClothName { get; set; } = string.Empty;
        [BsonElement("Description")]
        public string Description { get; set; } = string.Empty;
        [BsonElement("ImageURL")]
        public string ImageURL { get; set; } = string.Empty;
        [BsonElement("Price")]
        public double Price { get; set; } = 0;
        
        [BsonElement("Qty")]
        public int Quantity { get; set; }
        [BsonElement("Category")]
        public string Category { get; set; }

    }
}
