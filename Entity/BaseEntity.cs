using MongoDB.Bson.Serialization.Attributes;

namespace DataAccessLayer.Entity
{
    public class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
    }
}
