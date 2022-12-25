using MongoDB.Bson.Serialization.Attributes;

namespace ShopApp.shared.Models
{
    public class Item
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("CartId")]
        public string CartId { get; set; }
        [BsonElement("ClothId")]
        public string ClothId { get; set; }
        [BsonElement("Quantity")]
        public int Quantity { get; set; }


    }
}
