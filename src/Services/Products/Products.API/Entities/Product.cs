using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Products.API.Entities
{
    public class ProductItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        public string Summary { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}