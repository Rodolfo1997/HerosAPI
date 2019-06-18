using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HerosAPI.Models
{
    public class Hero
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Power")]
        public string Power { get; set; }

        [BsonElement("Team")]
        public string Team { get; set; }

        [BsonElement("Price")]
        public decimal Price { get; set; }
    }
}
