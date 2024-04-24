using MongoDB.Bson.Serialization.Attributes;

namespace DataAccessLayer.DTOs;
public class BaseDto
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;
}